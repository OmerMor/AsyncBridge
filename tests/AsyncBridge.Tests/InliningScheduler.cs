using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if NET45
namespace ReferenceAsync.Tests
#elif ATP
namespace AsyncTargetingPack.Tests
#else
namespace AsyncBridge.Tests
#endif
{
    /// <summary>
    /// A scheduler which never executes queued tasks so that inlining can be tested.
    /// </summary>
    internal sealed class InliningScheduler : TaskScheduler
    {
        private readonly List<Task> queue = new List<Task>();

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            lock (queue)
            {
                return queue.ToArray();
            }
        }

        protected override void QueueTask(Task task)
        {
            lock (queue)
            {
                queue.Add(task);
            }
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (taskWasPreviouslyQueued)
            {
                lock (queue)
                {
                    if (!queue.Remove(task)) return false;
                }
            }

            return TryExecuteTask(task);
        }
    }
}
