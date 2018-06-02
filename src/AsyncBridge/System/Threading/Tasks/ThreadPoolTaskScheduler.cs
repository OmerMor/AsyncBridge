// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/src/System/Threading/Tasks/ThreadPoolTaskScheduler.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT

#if NET20 || NET35
// =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
//
// TaskScheduler.cs
//
//
// This file contains the primary interface and management of tasks and queues.  
//
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace System.Threading.Tasks
{
    /// <summary>
    /// An implementation of TaskScheduler that uses the ThreadPool scheduler
    /// </summary>
    internal sealed class ThreadPoolTaskScheduler : TaskScheduler
    {
        private static readonly ConcurrentDictionary<Task, byte> Queue = new ConcurrentDictionary<Task, byte>();

        /// <summary>
        /// Constructs a new ThreadPool task scheduler object
        /// </summary>
        internal ThreadPoolTaskScheduler()
        {
            int id = base.Id; // force ID creation of the default scheduler
        }

        // static delegate for threads allocated to handle LongRunning tasks.
        private static readonly ParameterizedThreadStart s_longRunningThreadWork = s => ((Task)s).ExecuteEntryUnsafe();

        /// <summary>
        /// Schedules a task to the ThreadPool.
        /// </summary>
        /// <param name="task">The task to schedule.</param>
        protected internal override void QueueTask(Task task)
        {
            if ((task.Options & TaskCreationOptions.LongRunning) != 0)
            {
                // Run LongRunning tasks on their own dedicated thread.
                Thread thread = new Thread(s_longRunningThreadWork);
                thread.IsBackground = true; // Keep this thread from blocking process shutdown
                thread.Start(task);
            }
            else
            {
                if (!Queue.TryAdd(task, default)) throw new NotImplementedException("Same task instance queued twice");
                ThreadPool.UnsafeQueueUserWorkItem(state =>
                {
                    if (Queue.TryRemove(task, out _))
                    {
                        ((Task)state).ExecuteEntryUnsafe();
                    }
                }, task);
            }
        }

        /// <summary>
        /// This internal function will do this:
        ///   (1) If the task had previously been queued, attempt to pop it and return false if that fails.
        ///   (2) Return whether the task is executed
        /// 
        /// IMPORTANT NOTE: TryExecuteTaskInline will NOT throw task exceptions itself. Any wait code path using this function needs
        /// to account for exceptions that need to be propagated, and throw themselves accordingly.
        /// </summary>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If the task was previously scheduled, and we can't pop it, then return false.
            if (taskWasPreviouslyQueued && !Queue.TryRemove(task, out _))
                return false;

            task.ExecuteEntryUnsafe(); // handles switching Task.Current etc.

            return true;
        }

        protected internal override bool TryDequeue(Task task)
        {
            return Queue.TryRemove(task, out _);
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Queue.Keys;
        }

        /// <summary>
        /// This is the only scheduler that returns false for this property, indicating that the task entry codepath is unsafe (CAS free)
        /// since we know that the underlying scheduler already takes care of atomic transitions from queued to non-queued.
        /// </summary>
        internal override bool RequiresAtomicStartTransition
        {
            get { return false; }
        }
    }
}
#endif
