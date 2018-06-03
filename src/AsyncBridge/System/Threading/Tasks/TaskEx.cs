#if NET40 || PORTABLE
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    /// <summary>
    /// Contains static methods which would have been on <see cref="Task"/> if possible.
    /// </summary>
    public static class TaskEx
    {
        // Adapted from Task.cs which is also in this repo
        // https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/src/System/Threading/Tasks/Task.cs
        // Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT

        /// <summary>Gets a task that's already been completed successfully.</summary>
        public static Task CompletedTask { get; } = FromResult<object>(null);

        /// <summary>Creates an awaitable that asynchronously yields back to the current context when awaited.</summary>
        /// <returns>
        /// A context that, when awaited, will asynchronously transition back into the current context at the 
        /// time of the await. If the current SynchronizationContext is non-null, that is treated as the current context.
        /// Otherwise, TaskScheduler.Current is treated as the current context.
        /// </returns>
        public static YieldAwaitable Yield()
        {
            return new YieldAwaitable();
        }

        #region FromResult / FromException / FromCanceled

        /// <summary>Creates a <see cref="Task{TResult}"/> that's completed successfully with the specified result.</summary>
        /// <typeparam name="TResult">The type of the result returned by the task.</typeparam>
        /// <param name="result">The result to store into the completed task.</param>
        /// <returns>The successfully completed task.</returns>
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var source = new TaskCompletionSource<TResult>();
            source.SetResult(result);
            return source.Task;
        }

        /// <summary>Creates a <see cref="Task{TResult}"/> that's completed exceptionally with the specified exception.</summary>
        /// <typeparam name="TResult">The type of the result returned by the task.</typeparam>
        /// <param name="exception">The exception with which to complete the task.</param>
        /// <returns>The faulted task.</returns>
        public static Task FromException(Exception exception)
        {
            return FromException<VoidTaskResult>(exception);
        }

        /// <summary>Creates a <see cref="Task{TResult}"/> that's completed exceptionally with the specified exception.</summary>
        /// <typeparam name="TResult">The type of the result returned by the task.</typeparam>
        /// <param name="exception">The exception with which to complete the task.</param>
        /// <returns>The faulted task.</returns>
        public static Task<TResult> FromException<TResult>(Exception exception)
        {
            if (exception == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.exception);

            var source = new TaskCompletionSource<TResult>();
            source.SetException(exception);
            return source.Task;
        }

        /// <summary>Creates a <see cref="Task"/> that's completed due to cancellation with the specified token.</summary>
        /// <param name="cancellationToken">The token with which to complete the task.</param>
        /// <returns>The canceled task.</returns>
        public static Task FromCanceled(CancellationToken cancellationToken)
        {
            return FromCanceled<VoidTaskResult>(cancellationToken);
        }

        /// <summary>Creates a <see cref="Task{TResult}"/> that's completed due to cancellation with the specified token.</summary>
        /// <typeparam name="TResult">The type of the result returned by the task.</typeparam>
        /// <param name="cancellationToken">The token with which to complete the task.</param>
        /// <returns>The canceled task.</returns>
        public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.cancellationToken);

            var source = new TaskCompletionSource<TResult>();
            source.TrySetCanceled(cancellationToken);
            return source.Task;
        }

        #endregion

        #region Run methods


        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a Task handle for that work.
        /// </summary>
        /// <param name="action">The work to execute asynchronously</param>
        /// <returns>A Task that represents the work queued to execute in the ThreadPool.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="action"/> parameter was null.
        /// </exception>
        public static Task Run(Action action)
        {
            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a Task handle for that work.
        /// </summary>
        /// <param name="action">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work</param>
        /// <returns>A Task that represents the work queued to execute in the ThreadPool.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="action"/> parameter was null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.
        /// </exception>
        public static Task Run(Action action, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(action, cancellationToken, TaskCreationOptions.None, TaskScheduler.Default);
        }

        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a Task(TResult) handle for that work.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        /// <returns>A Task(TResult) that represents the work queued to execute in the ThreadPool.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="function"/> parameter was null.
        /// </exception>
        public static Task<TResult> Run<TResult>(Func<TResult> function)
        {
            return Task.Factory.StartNew(function, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a Task(TResult) handle for that work.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work</param>
        /// <returns>A Task(TResult) that represents the work queued to execute in the ThreadPool.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="function"/> parameter was null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.
        /// </exception>
        public static Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(function, cancellationToken, TaskCreationOptions.None, TaskScheduler.Default);
        }

        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a proxy for the
        /// Task returned by <paramref name="function"/>.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        /// <returns>A Task that represents a proxy for the Task returned by <paramref name="function"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="function"/> parameter was null.
        /// </exception>
        public static Task Run(Func<Task> function)
        {
            return Run(function, default(CancellationToken));
        }


        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a proxy for the
        /// Task returned by <paramref name="function"/>.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work</param>
        /// <returns>A Task that represents a proxy for the Task returned by <paramref name="function"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="function"/> parameter was null.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.
        /// </exception>
        public static Task Run(Func<Task> function, CancellationToken cancellationToken)
        {
            // Check arguments
            if (function == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.function);

            // Short-circuit if we are given a pre-canceled token
            if (cancellationToken.IsCancellationRequested)
                return TaskEx.FromCanceled(cancellationToken);

            return Run<Task>(function, cancellationToken).Unwrap();
        }

        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a proxy for the
        /// Task(TResult) returned by <paramref name="function"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the proxy Task.</typeparam>
        /// <param name="function">The work to execute asynchronously</param>
        /// <returns>A Task(TResult) that represents a proxy for the Task(TResult) returned by <paramref name="function"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="function"/> parameter was null.
        /// </exception>
        public static Task<TResult> Run<TResult>(Func<Task<TResult>> function)
        {
            return Run(function, default(CancellationToken));
        }

        /// <summary>
        /// Queues the specified work to run on the ThreadPool and returns a proxy for the
        /// Task(TResult) returned by <paramref name="function"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the proxy Task.</typeparam>
        /// <param name="function">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work</param>
        /// <returns>A Task(TResult) that represents a proxy for the Task(TResult) returned by <paramref name="function"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="function"/> parameter was null.
        /// </exception>
        public static Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken)
        {
            // Check arguments
            if (function == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.function);

            // Short-circuit if we are given a pre-canceled token
            if (cancellationToken.IsCancellationRequested)
                return TaskEx.FromCanceled<TResult>(cancellationToken);

            return Run<Task<TResult>>(function, cancellationToken).Unwrap();
        }


        #endregion

        #region Delay methods

        /// <summary>
        /// Creates a Task that will complete after a time delay.
        /// </summary>
        /// <param name="delay">The time span to wait before completing the returned Task</param>
        /// <returns>A Task that represents the time delay</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The <paramref name="delay"/> is less than -1 or greater than Int32.MaxValue.
        /// </exception>
        /// <remarks>
        /// After the specified time delay, the Task is completed in RanToCompletion state.
        /// </remarks>
        public static Task Delay(TimeSpan delay)
        {
            return Delay(delay, default(CancellationToken));
        }

        /// <summary>
        /// Creates a Task that will complete after a time delay.
        /// </summary>
        /// <param name="delay">The time span to wait before completing the returned Task</param>
        /// <param name="cancellationToken">The cancellation token that will be checked prior to completing the returned Task</param>
        /// <returns>A Task that represents the time delay</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The <paramref name="delay"/> is less than -1 or greater than Int32.MaxValue.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The provided <paramref name="cancellationToken"/> has already been disposed.
        /// </exception>        
        /// <remarks>
        /// If the cancellation token is signaled before the specified time delay, then the Task is completed in
        /// Canceled state.  Otherwise, the Task is completed in RanToCompletion state once the specified time
        /// delay has expired.
        /// </remarks>        
        public static Task Delay(TimeSpan delay, CancellationToken cancellationToken)
        {
            long totalMilliseconds = (long)delay.TotalMilliseconds;
            if (totalMilliseconds < -1 || totalMilliseconds > Int32.MaxValue)
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.delay, ExceptionResource.Task_Delay_InvalidDelay);
            }

            return Delay((int)totalMilliseconds, cancellationToken);
        }

        /// <summary>
        /// Creates a Task that will complete after a time delay.
        /// </summary>
        /// <param name="millisecondsDelay">The number of milliseconds to wait before completing the returned Task</param>
        /// <returns>A Task that represents the time delay</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The <paramref name="millisecondsDelay"/> is less than -1.
        /// </exception>
        /// <remarks>
        /// After the specified time delay, the Task is completed in RanToCompletion state.
        /// </remarks>
        public static Task Delay(int millisecondsDelay)
        {
            return Delay(millisecondsDelay, default(CancellationToken));
        }

        /// <summary>
        /// Creates a Task that will complete after a time delay.
        /// </summary>
        /// <param name="millisecondsDelay">The number of milliseconds to wait before completing the returned Task</param>
        /// <param name="cancellationToken">The cancellation token that will be checked prior to completing the returned Task</param>
        /// <returns>A Task that represents the time delay</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The <paramref name="millisecondsDelay"/> is less than -1.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The provided <paramref name="cancellationToken"/> has already been disposed.
        /// </exception>        
        /// <remarks>
        /// If the cancellation token is signaled before the specified time delay, then the Task is completed in
        /// Canceled state.  Otherwise, the Task is completed in RanToCompletion state once the specified time
        /// delay has expired.
        /// </remarks>        
        public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
        {
            // Throw on non-sensical time
            if (millisecondsDelay < -1)
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.millisecondsDelay, ExceptionResource.Task_Delay_InvalidMillisecondsDelay);
            }

            // some short-cuts in case quick completion is in order
            if (cancellationToken.IsCancellationRequested)
            {
                // return a Task created as already-Canceled
                return TaskEx.FromCanceled(cancellationToken);
            }
            else if (millisecondsDelay == 0)
            {
                // return a Task created as already-RanToCompletion
                return TaskEx.CompletedTask;
            }

            // Construct a promise-style Task to encapsulate our return value
            var promise = new DelayPromise(cancellationToken);

            // Register our cancellation token, if necessary.
            if (cancellationToken.CanBeCanceled)
            {
                promise.Registration = cancellationToken.Register(state => ((DelayPromise)state).Complete(), promise);
            }

            // ... and create our timer and make sure that it stays rooted.
            if (millisecondsDelay != Timeout.Infinite) // no need to create the timer if it's an infinite timeout
            {
                promise.Timer = new Timer(state => ((DelayPromise)state).Complete(), promise, millisecondsDelay, Timeout.Infinite);
            }

            // Return the timer proxy task
            return promise.TaskCompletionSource.Task;
        }

        /// <summary>Task that also stores the completion closure and logic for Task.Delay implementation.</summary>
        private sealed class DelayPromise 
        {
            internal DelayPromise(CancellationToken token)
            {
                this.Token = token;
            }

            internal readonly TaskCompletionSource<VoidTaskResult> TaskCompletionSource = new TaskCompletionSource<VoidTaskResult>();
            internal readonly CancellationToken Token;
            internal CancellationTokenRegistration Registration;
            internal Timer Timer;

            internal void Complete()
            {
                // Transition the task to completed.
                bool setSucceeded;

                if (Token.IsCancellationRequested)
                {
                    setSucceeded = TaskCompletionSource.TrySetCanceled(Token);
                }
                else
                {
                    setSucceeded = TaskCompletionSource.TrySetResult(default(VoidTaskResult));
                }

                // If we set the value, also clean up.
                if (setSucceeded)
                {
                    Timer?.Dispose();
                    Registration.Dispose();
                }
            }
        }
        #endregion

        #region WhenAll
        /// <summary>
        /// Creates a task that will complete when all of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>
        /// <para>
        /// If any of the supplied tasks completes in a faulted state, the returned task will also complete in a Faulted state, 
        /// where its exceptions will contain the aggregation of the set of unwrapped exceptions from each of the supplied tasks.  
        /// </para>
        /// <para>
        /// If none of the supplied tasks faulted but at least one of them was canceled, the returned task will end in the Canceled state.
        /// </para>
        /// <para>
        /// If none of the tasks faulted and none of the tasks were canceled, the resulting task will end in the RanToCompletion state.   
        /// </para>
        /// <para>
        /// If the supplied array/enumerable contains no tasks, the returned task will immediately transition to a RanToCompletion 
        /// state before it's returned to the caller.  
        /// </para>
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> collection contained a null task.
        /// </exception>
        public static Task WhenAll(IEnumerable<Task> tasks)
        {
            // Take a more efficient path if tasks is actually an array
            Task[] taskArray = tasks as Task[];
            if (taskArray != null)
            {
                return WhenAll(taskArray);
            }

            // Skip a List allocation/copy if tasks is a collection
            ICollection<Task> taskCollection = tasks as ICollection<Task>;
            if (taskCollection != null)
            {
                int index = 0;
                taskArray = new Task[taskCollection.Count];
                foreach (var task in tasks)
                {
                    if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                    taskArray[index++] = task;
                }
                return InternalWhenAll(taskArray);
            }

            // Do some argument checking and convert tasks to a List (and later an array).
            if (tasks == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.tasks);
            List<Task> taskList = new List<Task>();
            foreach (Task task in tasks)
            {
                if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                taskList.Add(task);
            }

            // Delegate the rest to InternalWhenAll()
            return InternalWhenAll(taskList.ToArray());
        }

        /// <summary>
        /// Creates a task that will complete when all of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>
        /// <para>
        /// If any of the supplied tasks completes in a faulted state, the returned task will also complete in a Faulted state, 
        /// where its exceptions will contain the aggregation of the set of unwrapped exceptions from each of the supplied tasks.  
        /// </para>
        /// <para>
        /// If none of the supplied tasks faulted but at least one of them was canceled, the returned task will end in the Canceled state.
        /// </para>
        /// <para>
        /// If none of the tasks faulted and none of the tasks were canceled, the resulting task will end in the RanToCompletion state.   
        /// </para>
        /// <para>
        /// If the supplied array/enumerable contains no tasks, the returned task will immediately transition to a RanToCompletion 
        /// state before it's returned to the caller.  
        /// </para>
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> array contained a null task.
        /// </exception>
        public static Task WhenAll(params Task[] tasks)
        {
            // Do some argument checking and make a defensive copy of the tasks array
            if (tasks == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.tasks);

            int taskCount = tasks.Length;
            if (taskCount == 0) return InternalWhenAll(tasks); // Small optimization in the case of an empty array.

            Task[] tasksCopy = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                Task task = tasks[i];
                if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                tasksCopy[i] = task;
            }

            // The rest can be delegated to InternalWhenAll()
            return InternalWhenAll(tasksCopy);
        }

        // Some common logic to support WhenAll() methods
        // tasks should be a defensive copy.
        private static Task InternalWhenAll(Task[] tasks)
        {
            Debug.Assert(tasks != null, "Expected a non-null tasks array");
            return (tasks.Length == 0) ? // take shortcut if there are no tasks upon which to wait
                TaskEx.CompletedTask :
                new WhenAllPromise(tasks).TaskCompletionSource.Task;
        }

        // A Task<VoidTaskResult> that gets completed when all of its constituent tasks complete.
        // Completion logic will analyze the antecedents in order to choose completion status.
        // This type allows us to replace this logic:
        //      Task<VoidTaskResult> promise = new Task<VoidTaskResult>(...);
        //      Action<Task> completionAction = delegate { <completion logic>};
        //      TaskFactory.CommonCWAllLogic(tasksCopy).AddCompletionAction(completionAction);
        //      return promise;
        // which involves several allocations, with this logic:
        //      return new WhenAllPromise(tasksCopy);
        // which saves a couple of allocations and enables debugger notification specialization.
        //
        // Used in InternalWhenAll(Task[])
        private sealed class WhenAllPromise
        {
            internal readonly TaskCompletionSource<VoidTaskResult> TaskCompletionSource = new TaskCompletionSource<VoidTaskResult>();

            /// <summary>
            /// Stores all of the constituent tasks.  Tasks clear themselves out of this
            /// array as they complete, but only if they don't have their wait notification bit set.
            /// </summary>
            private readonly Task[] m_tasks;
            /// <summary>The number of tasks remaining to complete.</summary>
            private int m_count;

            internal WhenAllPromise(Task[] tasks)
            {
                Debug.Assert(tasks != null, "Expected a non-null task array");
                Debug.Assert(tasks.Length > 0, "Expected a non-zero length task array");

                m_tasks = tasks;
                m_count = tasks.Length;

                foreach (var task in tasks)
                {
                    if (task.IsCompleted) this.Invoke(task); // short-circuit the completion action, if possible
                    else task.ContinueWith(Invoke); // simple completion action
                }
            }

            public void Invoke(Task completedTask)
            {
                // Decrement the count, and only continue to complete the promise if we're the last one.
                if (Interlocked.Decrement(ref m_count) == 0)
                {
                    // Set up some accounting variables
                    List<Exception> observedExceptions = null;
                    Task canceledTask = null;

                    // Loop through antecedents:
                    //   If any one of them faults, the result will be faulted
                    //   If none fault, but at least one is canceled, the result will be canceled
                    //   If none fault or are canceled, then result will be RanToCompletion
                    for (int i = 0; i < m_tasks.Length; i++)
                    {
                        var task = m_tasks[i];
                        Debug.Assert(task != null, "Constituent task in WhenAll should never be null");

                        if (task.IsFaulted)
                        {
                            if (observedExceptions == null) observedExceptions = new List<Exception>();
                            observedExceptions.AddRange(task.Exception.InnerExceptions);
                        }
                        else if (task.IsCanceled)
                        {
                            if (canceledTask == null) canceledTask = task; // use the first task that's canceled
                        }

                        m_tasks[i] = null; // avoid holding onto tasks unnecessarily
                    }

                    if (observedExceptions != null)
                    {
                        Debug.Assert(observedExceptions.Count > 0, "Expected at least one exception");

                        //We don't need to TraceOperationCompleted here because TrySetException will call Finish and we'll log it there

                        TaskCompletionSource.TrySetException(observedExceptions);
                    }
                    else if (canceledTask != null)
                    {
                        TaskCompletionSource.TrySetCanceled(
                            (canceledTask.Exception.InnerException as OperationCanceledException)?.CancellationToken ?? default);
                    }
                    else
                    {
                        TaskCompletionSource.TrySetResult(default(VoidTaskResult));
                    }
                }
                Debug.Assert(m_count >= 0, "Count should never go below 0");
            }
        }

        /// <summary>
        /// Creates a task that will complete when all of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>
        /// <para>
        /// If any of the supplied tasks completes in a faulted state, the returned task will also complete in a Faulted state, 
        /// where its exceptions will contain the aggregation of the set of unwrapped exceptions from each of the supplied tasks.  
        /// </para>
        /// <para>
        /// If none of the supplied tasks faulted but at least one of them was canceled, the returned task will end in the Canceled state.
        /// </para>
        /// <para>
        /// If none of the tasks faulted and none of the tasks were canceled, the resulting task will end in the RanToCompletion state.  
        /// The Result of the returned task will be set to an array containing all of the results of the 
        /// supplied tasks in the same order as they were provided (e.g. if the input tasks array contained t1, t2, t3, the output 
        /// task's Result will return an TResult[] where arr[0] == t1.Result, arr[1] == t2.Result, and arr[2] == t3.Result). 
        /// </para>
        /// <para>
        /// If the supplied array/enumerable contains no tasks, the returned task will immediately transition to a RanToCompletion 
        /// state before it's returned to the caller.  The returned TResult[] will be an array of 0 elements.
        /// </para>
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> collection contained a null task.
        /// </exception>       
        public static Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks)
        {
            // Take a more efficient route if tasks is actually an array
            Task<TResult>[] taskArray = tasks as Task<TResult>[];
            if (taskArray != null)
            {
                return WhenAll<TResult>(taskArray);
            }

            // Skip a List allocation/copy if tasks is a collection
            ICollection<Task<TResult>> taskCollection = tasks as ICollection<Task<TResult>>;
            if (taskCollection != null)
            {
                int index = 0;
                taskArray = new Task<TResult>[taskCollection.Count];
                foreach (var task in tasks)
                {
                    if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                    taskArray[index++] = task;
                }
                return InternalWhenAll<TResult>(taskArray);
            }

            // Do some argument checking and convert tasks into a List (later an array)
            if (tasks == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.tasks);
            List<Task<TResult>> taskList = new List<Task<TResult>>();
            foreach (Task<TResult> task in tasks)
            {
                if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                taskList.Add(task);
            }

            // Delegate the rest to InternalWhenAll<TResult>().
            return InternalWhenAll<TResult>(taskList.ToArray());
        }

        /// <summary>
        /// Creates a task that will complete when all of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>
        /// <para>
        /// If any of the supplied tasks completes in a faulted state, the returned task will also complete in a Faulted state, 
        /// where its exceptions will contain the aggregation of the set of unwrapped exceptions from each of the supplied tasks.  
        /// </para>
        /// <para>
        /// If none of the supplied tasks faulted but at least one of them was canceled, the returned task will end in the Canceled state.
        /// </para>
        /// <para>
        /// If none of the tasks faulted and none of the tasks were canceled, the resulting task will end in the RanToCompletion state.  
        /// The Result of the returned task will be set to an array containing all of the results of the 
        /// supplied tasks in the same order as they were provided (e.g. if the input tasks array contained t1, t2, t3, the output 
        /// task's Result will return an TResult[] where arr[0] == t1.Result, arr[1] == t2.Result, and arr[2] == t3.Result). 
        /// </para>
        /// <para>
        /// If the supplied array/enumerable contains no tasks, the returned task will immediately transition to a RanToCompletion 
        /// state before it's returned to the caller.  The returned TResult[] will be an array of 0 elements.
        /// </para>
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> array contained a null task.
        /// </exception>
        public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks)
        {
            // Do some argument checking and make a defensive copy of the tasks array
            if (tasks == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.tasks);

            int taskCount = tasks.Length;
            if (taskCount == 0) return InternalWhenAll<TResult>(tasks); // small optimization in the case of an empty task array

            Task<TResult>[] tasksCopy = new Task<TResult>[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                Task<TResult> task = tasks[i];
                if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                tasksCopy[i] = task;
            }

            // Delegate the rest to InternalWhenAll<TResult>()
            return InternalWhenAll<TResult>(tasksCopy);
        }

        // Some common logic to support WhenAll<TResult> methods
        private static Task<TResult[]> InternalWhenAll<TResult>(Task<TResult>[] tasks)
        {
            Debug.Assert(tasks != null, "Expected a non-null tasks array");
            return (tasks.Length == 0) ? // take shortcut if there are no tasks upon which to wait
                TaskEx.FromResult(new TResult[0]) :
                new WhenAllPromise<TResult>(tasks).TaskCompletionSource.Task;
        }

        // A Task<T> that gets completed when all of its constituent tasks complete.
        // Completion logic will analyze the antecedents in order to choose completion status.
        // See comments for non-generic version of WhenAllPromise class.
        //
        // Used in InternalWhenAll<TResult>(Task<TResult>[])
        private sealed class WhenAllPromise<T>
        {
            internal readonly TaskCompletionSource<T[]> TaskCompletionSource = new TaskCompletionSource<T[]>();
            /// <summary>
            /// Stores all of the constituent tasks.  Tasks clear themselves out of this
            /// array as they complete, but only if they don't have their wait notification bit set.
            /// </summary>
            private readonly Task<T>[] m_tasks;
            /// <summary>The number of tasks remaining to complete.</summary>
            private int m_count;

            internal WhenAllPromise(Task<T>[] tasks)
            {
                Debug.Assert(tasks != null, "Expected a non-null task array");
                Debug.Assert(tasks.Length > 0, "Expected a non-zero length task array");

                m_tasks = tasks;
                m_count = tasks.Length;

                foreach (var task in tasks)
                {
                    if (task.IsCompleted) this.Invoke(task); // short-circuit the completion action, if possible
                    else task.ContinueWith(Invoke); // simple completion action
                }
            }

            public void Invoke(Task ignored)
            {
                // Decrement the count, and only continue to complete the promise if we're the last one.
                if (Interlocked.Decrement(ref m_count) == 0)
                {
                    // Set up some accounting variables
                    T[] results = new T[m_tasks.Length];
                    List<Exception> observedExceptions = null;
                    Task canceledTask = null;

                    // Loop through antecedents:
                    //   If any one of them faults, the result will be faulted
                    //   If none fault, but at least one is canceled, the result will be canceled
                    //   If none fault or are canceled, then result will be RanToCompletion
                    for (int i = 0; i < m_tasks.Length; i++)
                    {
                        Task<T> task = m_tasks[i];
                        Debug.Assert(task != null, "Constituent task in WhenAll should never be null");

                        if (task.IsFaulted)
                        {
                            if (observedExceptions == null) observedExceptions = new List<Exception>();
                            observedExceptions.AddRange(task.Exception.InnerExceptions);
                        }
                        else if (task.IsCanceled)
                        {
                            if (canceledTask == null) canceledTask = task; // use the first task that's canceled
                        }
                        else
                        {
                            Debug.Assert(task.Status == TaskStatus.RanToCompletion);
                            results[i] = task.Result;
                        }

                        m_tasks[i] = null; // avoid holding onto tasks unnecessarily
                    }

                    if (observedExceptions != null)
                    {
                        Debug.Assert(observedExceptions.Count > 0, "Expected at least one exception");

                        //We don't need to TraceOperationCompleted here because TrySetException will call Finish and we'll log it there

                        TaskCompletionSource.TrySetException(observedExceptions);
                    }
                    else if (canceledTask != null)
                    {
                        TaskCompletionSource.TrySetCanceled(
                            (canceledTask.Exception.InnerException as OperationCanceledException)?.CancellationToken ?? default);
                    }
                    else
                    {
                        TaskCompletionSource.TrySetResult(results);
                    }
                }
                Debug.Assert(m_count >= 0, "Count should never go below 0");
            }
        }
        #endregion

        #region WhenAny

        private static class PerTResult<TResult>
        {
            // Delegate used by:
            //     public static Task<Task<TResult>> WhenAny<TResult>(IEnumerable<Task<TResult>> tasks);
            //     public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);
            // Used to "cast" from Task<Task> to Task<Task<TResult>>.
            internal static readonly Func<Task<Task>, Task<TResult>> TaskWhenAnyCast = completed => (Task<TResult>)completed.Result;
        }

        /// <summary>
        /// Creates a task that will complete when any of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of one of the supplied tasks.  The return Task's Result is the task that completed.</returns>
        /// <remarks>
        /// The returned task will complete when any of the supplied tasks has completed.  The returned task will always end in the RanToCompletion state 
        /// with its Result set to the first task to complete.  This is true even if the first task to complete ended in the Canceled or Faulted state.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> array contained a null task, or was empty.
        /// </exception>
        public static Task<Task> WhenAny(params Task[] tasks)
        {
            if (tasks == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.tasks);
            if (tasks.Length == 0)
            {
                ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_EmptyTaskList, ExceptionArgument.tasks);
            }

            // Make a defensive copy, as the user may manipulate the tasks array
            // after we return but before the WhenAny asynchronously completes.
            int taskCount = tasks.Length;
            Task[] tasksCopy = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                Task task = tasks[i];
                if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                tasksCopy[i] = task;
            }

            // Previously implemented CommonCWAnyLogic() can handle the rest
            return CommonCWAnyLogic(tasksCopy);
        }

        /// <summary>
        /// Creates a task that will complete when any of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of one of the supplied tasks.  The return Task's Result is the task that completed.</returns>
        /// <remarks>
        /// The returned task will complete when any of the supplied tasks has completed.  The returned task will always end in the RanToCompletion state 
        /// with its Result set to the first task to complete.  This is true even if the first task to complete ended in the Canceled or Faulted state.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> collection contained a null task, or was empty.
        /// </exception>
        public static Task<Task> WhenAny(IEnumerable<Task> tasks)
        {
            if (tasks == null) ThrowHelper.ThrowArgumentNullException(ExceptionArgument.tasks);

            // Make a defensive copy, as the user may manipulate the tasks collection
            // after we return but before the WhenAny asynchronously completes.
            List<Task> taskList = new List<Task>();
            foreach (Task task in tasks)
            {
                if (task == null) ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_NullTask, ExceptionArgument.tasks);
                taskList.Add(task);
            }

            if (taskList.Count == 0)
            {
                ThrowHelper.ThrowArgumentException(ExceptionResource.Task_MultiTaskContinuation_EmptyTaskList, ExceptionArgument.tasks);
            }

            // Previously implemented CommonCWAnyLogic() can handle the rest
            return CommonCWAnyLogic(taskList);
        }

        /// <summary>
        /// Creates a task that will complete when any of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of one of the supplied tasks.  The return Task's Result is the task that completed.</returns>
        /// <remarks>
        /// The returned task will complete when any of the supplied tasks has completed.  The returned task will always end in the RanToCompletion state 
        /// with its Result set to the first task to complete.  This is true even if the first task to complete ended in the Canceled or Faulted state.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> array contained a null task, or was empty.
        /// </exception>
        public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks)
        {
            // We would just like to do this:
            //    return (Task<Task<TResult>>) WhenAny( (Task[]) tasks);
            // but classes are not covariant to enable casting Task<TResult> to Task<Task<TResult>>.

            // Call WhenAny(Task[]) for basic functionality
            Task<Task> intermediate = WhenAny((Task[])tasks);

            // Return a continuation task with the correct result type
            return intermediate.ContinueWith(PerTResult<TResult>.TaskWhenAnyCast, default(CancellationToken),
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        /// <summary>
        /// Creates a task that will complete when any of the supplied tasks have completed.
        /// </summary>
        /// <param name="tasks">The tasks to wait on for completion.</param>
        /// <returns>A task that represents the completion of one of the supplied tasks.  The return Task's Result is the task that completed.</returns>
        /// <remarks>
        /// The returned task will complete when any of the supplied tasks has completed.  The returned task will always end in the RanToCompletion state 
        /// with its Result set to the first task to complete.  This is true even if the first task to complete ended in the Canceled or Faulted state.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="tasks"/> argument was null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="tasks"/> collection contained a null task, or was empty.
        /// </exception>
        public static Task<Task<TResult>> WhenAny<TResult>(IEnumerable<Task<TResult>> tasks)
        {
            // We would just like to do this:
            //    return (Task<Task<TResult>>) WhenAny( (IEnumerable<Task>) tasks);
            // but classes are not covariant to enable casting Task<TResult> to Task<Task<TResult>>.

            // Call WhenAny(IEnumerable<Task>) for basic functionality
            Task<Task> intermediate = WhenAny((IEnumerable<Task>)tasks);

            // Return a continuation task with the correct result type
            return intermediate.ContinueWith(PerTResult<TResult>.TaskWhenAnyCast, default(CancellationToken),
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        // A Task<Task> that will be completed the first time that Invoke is called.
        // It allows us to replace this logic:
        //      Task<Task> promise = new Task<Task>(...);
        //      Action<Task> completionAction = delegate(Task completingTask) { promise.TrySetResult(completingTask); }
        //      for(int i=0; i<tasksCopy.Length; i++) tasksCopy[i].AddCompletionAction(completionAction);
        // with this logic:
        //      CompletionOnInvokePromise promise = new CompletionOnInvokePromise(tasksCopy);
        //      for(int i=0; i<tasksCopy.Length; i++) tasksCopy[i].AddCompletionAction(promise);
        // which saves a couple of allocations.
        //
        // Used in TaskFactory.CommonCWAnyLogic(), below.
        internal sealed class CompleteOnInvokePromise
        {
            internal readonly TaskCompletionSource<Task> TaskCompletionSource = new TaskCompletionSource<Task>();

            private IList<Task> _tasks; // must track this for cleanup
            private int m_firstTaskAlreadyCompleted;

            public CompleteOnInvokePromise(IList<Task> tasks)
            {
                Debug.Assert(tasks != null, "Expected non-null collection of tasks");
                _tasks = tasks;
            }

            public void Invoke(Task completingTask)
            {
                if (m_firstTaskAlreadyCompleted == 0 &&
                    Interlocked.Exchange(ref m_firstTaskAlreadyCompleted, 1) == 0)
                {
                    bool success = TaskCompletionSource.TrySetResult(completingTask);
                    Debug.Assert(success, "Only one task should have gotten to this point, and thus this must be successful.");
                    _tasks = null;
                }
            }

            public bool InvokeMayRunArbitraryCode { get { return true; } }
        }
        // Common ContinueWhenAny logic
        // If the tasks list is not an array, it must be an internal defensive copy so that 
        // we don't need to be concerned about concurrent modifications to the list.  If the task list
        // is an array, it should be a defensive copy if this functionality is being used
        // asynchronously (e.g. WhenAny) rather than synchronously (e.g. WaitAny).
        internal static Task<Task> CommonCWAnyLogic(IList<Task> tasks)
        {
            Debug.Assert(tasks != null);

            // Create a promise task to be returned to the user.
            // (If this logic ever changes, also update CommonCWAnyLogicCleanup.)
            var promise = new CompleteOnInvokePromise(tasks);

            // At the completion of any of the tasks, complete the promise.

            bool checkArgsOnly = false;
            int numTasks = tasks.Count;
            for (int i = 0; i < numTasks; i++)
            {
                var task = tasks[i];
                if (task == null) throw new ArgumentException(SR.Task_MultiTaskContinuation_NullTask, nameof(tasks));

                if (checkArgsOnly) continue;

                // If the promise has already completed, don't bother with checking any more tasks.
                if (promise.TaskCompletionSource.Task.IsCompleted)
                {
                    checkArgsOnly = true;
                }
                // If a task has already completed, complete the promise.
                else if (task.IsCompleted)
                {
                    promise.Invoke(task);
                    checkArgsOnly = true;
                }
                // Otherwise, add the completion action and keep going.
                else
                {
                    task.ContinueWith(promise.Invoke);
                }
            }

            return promise.TaskCompletionSource.Task;
        }
        #endregion
    }
}
#endif
