using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable CheckNamespace

/// <summary>
/// Provides extension methods for threading-related types.
/// </summary>
/// 
/// <summary>
/// Asynchronous wrappers for .NET Framework operations.
/// </summary>
/// 
/// <summary>
/// Provides extension methods for threading-related types.
/// </summary>
/// 
/// <remarks>
/// AsyncCtpThreadingExtensions is a placeholder.
/// </remarks>
public static class AsyncCompatLibExtensions
{
    /// <summary>
    /// Gets an awaiter used to await this <see cref="T:System.Threading.Tasks.Task"/>.
    /// </summary>
    /// <param name="task">The task to await.</param>
    /// <returns>
    /// An awaiter instance.
    /// </returns>
    public static TaskAwaiter GetAwaiter(this Task task)
    {
        if (task == null)
            throw new ArgumentNullException("task");
        
        return new TaskAwaiter(task);
    }

    /// <summary>
    /// Gets an awaiter used to await this <see cref="T:System.Threading.Tasks.Task"/>.
    /// </summary>
    /// <typeparam name="TResult">Specifies the type of data returned by the task.</typeparam>
    /// <param name="task">The task to await.</param>
    /// <returns>
    /// An awaiter instance.
    /// </returns>
    public static TaskAwaiter<TResult> GetAwaiter<TResult>(this Task<TResult> task)
    {
        if (task == null)
            throw new ArgumentNullException("task");
        
        return new TaskAwaiter<TResult>(task);
    }

    /// <summary>
    /// Creates and configures an awaitable object for awaiting the specified task.
    /// </summary>
    /// <param name="task">The task to be awaited.</param>
    /// <param name="continueOnCapturedContext">true to automatic marshal back to the original call site's current SynchronizationContext
    ///             or TaskScheduler; otherwise, false.</param>
    /// <returns>
    /// The instance to be awaited.
    /// </returns>
    public static ConfiguredTaskAwaitable<TResult> ConfigureAwait<TResult>(this Task<TResult> task, bool continueOnCapturedContext)
    {
        if (task == null)
            throw new ArgumentNullException("task");

        return new ConfiguredTaskAwaitable<TResult>(task, continueOnCapturedContext);
    }

    /// <summary>
    /// Creates and configures an awaitable object for awaiting the specified task.
    /// </summary>
    /// <param name="task">The task to be awaited.</param>
    /// <param name="continueOnCapturedContext">true to automatic marshal back to the original call site's current SynchronizationContext
    ///             or TaskScheduler; otherwise, false.</param>
    /// <returns>
    /// The instance to be awaited.
    /// </returns>
    public static ConfiguredTaskAwaitable ConfigureAwait(this Task task, bool continueOnCapturedContext)
    {
        if (task == null)
            throw new ArgumentNullException("task");

        return new ConfiguredTaskAwaitable(task, continueOnCapturedContext);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith(this Task task, Action<Task, object> action, object state)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state));
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <typeparam name="TInResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith<TInResult>(this Task<TInResult> task, Action<Task<TInResult>, object> action, object state)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state));
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith(this Task task, Action<Task, object> action, object state, CancellationToken token)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <typeparam name="TInResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith<TInResult>(this Task<TInResult> task, Action<Task<TInResult>, object> action, object state, CancellationToken token)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <param name="taskOptions">A set of task continuation options to apply</param>
    /// <param name="scheduler">The task scheduler to schedule the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith(this Task task, Action<Task, object> action, object state, CancellationToken token, TaskContinuationOptions taskOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, taskOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <typeparam name="TInResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <param name="taskOptions">A set of task continuation options to apply</param>
    /// <param name="scheduler">The task scheduler to schedule the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith<TInResult>(this Task<TInResult> task, Action<Task<TInResult>, object> action, object state, CancellationToken token, TaskContinuationOptions taskOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, taskOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> action, object state, CancellationToken token)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> action, object state, CancellationToken token, TaskContinuationOptions taskOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, taskOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TInResult, TResult>(this Task<TInResult> task, Func<Task<TInResult>, object, TResult> action, object state, CancellationToken token)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TInResult, TResult>(this Task<TInResult> task, Func<Task<TInResult>, object, TResult> action, object state, CancellationToken token, TaskContinuationOptions taskOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith((innerTask) => action(innerTask, state), token, taskOptions, scheduler);
    }

    /// <summary>
    /// Causes a cancellation token source to cancel after a specified time
    /// </summary>
    /// <param name="cancelSource">The cancellation token source to cancel</param>
    /// <param name="delay">The time to wait before cancellation</param>
    public static void CancelAfter(this CancellationTokenSource cancelSource, TimeSpan delay)
    {
        Timer MyTimer = null;

        MyTimer = new Timer(state =>
        {
            MyTimer.Dispose();

            try
            {
                if (cancelSource.Token.CanBeCanceled)
                    cancelSource.Cancel();
            }
            catch (ObjectDisposedException) // If the cancellation token has been disposed of, ignore the exception
            {
            }
        }, null, Timeout.Infinite, Timeout.Infinite);

        MyTimer.Change(delay, new TimeSpan(0, 0, 0, 0, -1));
    }
}
// ReSharper restore CheckNamespace
