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
        return task.ContinueWith(new ContinueWithState(action, state).ContinueWith);
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
        return task.ContinueWith(new ContinueWithState(action, state).ContinueWith, token);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="taskOptions">A set of task continuation options to apply</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith(this Task task, Action<Task, object> action, object state, TaskContinuationOptions taskOptions)
    {
        return task.ContinueWith(new ContinueWithState(action, state).ContinueWith, CancellationToken.None, taskOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="scheduler">The task scheduler to schedule the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith(this Task task, Action<Task, object> action, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithState(action, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
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
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith<TInResult>(this Task<TInResult> task, Action<Task<TInResult>, object> action, object state)
    {
        return task.ContinueWith(new ContinueWithInState<TInResult>(action, state).ContinueWith);
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
        return task.ContinueWith(new ContinueWithInState<TInResult>(action, state).ContinueWith, token);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <typeparam name="TInResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="taskOptions">A set of task continuation options to apply</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith<TInResult>(this Task<TInResult> task, Action<Task<TInResult>, object> action, object state, TaskContinuationOptions taskOptions)
    {
        return task.ContinueWith(new ContinueWithInState<TInResult>(action, state).ContinueWith, CancellationToken.None, taskOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <typeparam name="TInResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="scheduler">The task scheduler to schedule the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task ContinueWith<TInResult>(this Task<TInResult> task, Action<Task<TInResult>, object> action, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInState<TInResult>(action, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
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
        return task.ContinueWith(new ContinueWithInState<TInResult>(action, state).ContinueWith, token, taskOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> action, object state)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(action, state).ContinueWith);
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
        return task.ContinueWith(new ContinueWithOutState<TResult>(action, state).ContinueWith, token);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="taskOptions">Options for when the continuation is scheduled</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> action, object state, TaskContinuationOptions taskOptions)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(action, state).ContinueWith, CancellationToken.None, taskOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="scheduler">The Task Scheduler to associate with the continuation Task</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> action, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(action, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <param name="taskOptions">Options for when the continuation is scheduled</param>
    /// <param name="scheduler">The Task Scheduler to associate with the continuation Task</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> action, object state, CancellationToken token, TaskContinuationOptions taskOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(action, state).ContinueWith, token, taskOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TInResult, TResult>(this Task<TInResult> task, Func<Task<TInResult>, object, TResult> action, object state)
    {
        return task.ContinueWith(new ContinueWithInOutState<TInResult, TResult>(action, state).ContinueWith);
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
        return task.ContinueWith(new ContinueWithInOutState<TInResult, TResult>(action, state).ContinueWith, token);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="taskOptions">Options for when the continuation is scheduled</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TInResult, TResult>(this Task<TInResult> task, Func<Task<TInResult>, object, TResult> action, object state, TaskContinuationOptions taskOptions)
    {
        return task.ContinueWith(new ContinueWithInOutState<TInResult, TResult>(action, state).ContinueWith, CancellationToken.None, taskOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="scheduler">The Task Scheduler to associate with the continuation Task</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TInResult, TResult>(this Task<TInResult> task, Func<Task<TInResult>, object, TResult> action, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInOutState<TInResult, TResult>(action, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes asynchronously when the target Task completes
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="action">The continuation method to execute</param>
    /// <param name="state">A state object to pass to the continuation</param>
    /// <param name="token">A cancellation token to abort the continuation</param>
    /// <param name="taskOptions">Options for when the continuation is scheduled</param>
    /// <param name="scheduler">The Task Scheduler to associate with the continuation Task</param>
    /// <returns>A task representing the continuation status</returns>
    public static Task<TResult> ContinueWith<TInResult, TResult>(this Task<TInResult> task, Func<Task<TInResult>, object, TResult> action, object state, CancellationToken token, TaskContinuationOptions taskOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInOutState<TInResult, TResult>(action, state).ContinueWith, token, taskOptions, scheduler);
    }

    private sealed class ContinueWithState
    {
        private readonly Action<Task, object> _Callback;
        private readonly object _State;

        internal ContinueWithState(Action<Task, object> callback, object state)
        {
            _Callback = callback;
            _State = state;
        }

        internal void ContinueWith(Task task)
        {
            _Callback(task, _State);
        }
    }

    private sealed class ContinueWithInState<TIn>
    {
        private readonly Action<Task<TIn>, object> _Callback;
        private readonly object _State;

        internal ContinueWithInState(Action<Task<TIn>, object> callback, object state)
        {
            _Callback = callback;
            _State = state;
        }

        internal void ContinueWith(Task<TIn> task)
        {
            _Callback(task, _State);
        }
    }

    private sealed class ContinueWithOutState<TOut>
    {
        private readonly Func<Task, object, TOut> _Callback;
        private readonly object _State;

        internal ContinueWithOutState(Func<Task, object, TOut> callback, object state)
        {
            _Callback = callback;
            _State = state;
        }

        internal TOut ContinueWith(Task task)
        {
            return _Callback(task, _State);
        }
    }

    private sealed class ContinueWithInOutState<TIn, TOut>
    {
        private readonly Func<Task<TIn>, object, TOut> _Callback;
        private readonly object _State;

        internal ContinueWithInOutState(Func<Task<TIn>, object, TOut> callback, object state)
        {
            _Callback = callback;
            _State = state;
        }

        internal TOut ContinueWith(Task<TIn> task)
        {
            return _Callback(task, _State);
        }
    }
}
// ReSharper restore CheckNamespace
