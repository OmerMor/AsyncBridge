#if !NET20
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
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task as and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    public static Task ContinueWith(this Task task, Action<Task, object> continuationAction, object state)
    {
        return task.ContinueWith(new ContinueWithState(continuationAction, state).ContinueWith);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="cancellationToken"> The <see cref="CancellationToken"/> that will be assigned to the new continuation task.</param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task ContinueWith(this Task task, Action<Task, object> continuationAction, object state, CancellationToken cancellationToken)
    {
        return task.ContinueWith(new ContinueWithState(continuationAction, state).ContinueWith, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed. If the continuation criteria specified through the <paramref
    /// name="continuationOptions"/> parameter are not met, the continuation task will be canceled
    /// instead of scheduled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    public static Task ContinueWith(this Task task, Action<Task, object> continuationAction, object state, TaskContinuationOptions continuationOptions)
    {
        return task.ContinueWith(new ContinueWithState(continuationAction, state).ContinueWith, CancellationToken.None, continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task"/> completes.  When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    public static Task ContinueWith(this Task task, Action<Task, object> continuationAction, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithState(continuationAction, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new continuation task.</param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its
    /// execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed. If the criteria specified through the <paramref name="continuationOptions"/> parameter
    /// are not met, the continuation task will be canceled instead of scheduled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task ContinueWith(this Task task, Action<Task, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithState(continuationAction, state).ContinueWith, cancellationToken, continuationOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state)
    {
        return task.ContinueWith(new ContinueWithInState<TResult>(continuationAction, state).ContinueWith);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new continuation task.</param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken)
    {
        return task.ContinueWith(new ContinueWithInState<TResult>(continuationAction, state).ContinueWith, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed. If the continuation criteria specified through the <paramref
    /// name="continuationOptions"/> parameter are not met, the continuation task will be canceled
    /// instead of scheduled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state, TaskContinuationOptions continuationOptions)
    {
        return task.ContinueWith(new ContinueWithInState<TResult>(continuationAction, state).ContinueWith, CancellationToken.None, continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInState<TResult>(continuationAction, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of result from the target task</typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationAction">
    /// An action to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation action.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new continuation task.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its
    /// execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task"/> will not be scheduled for execution until the current task has
    /// completed. If the criteria specified through the <paramref name="continuationOptions"/> parameter
    /// are not met, the continuation task will be canceled instead of scheduled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationAction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInState<TResult>(continuationAction, state).ContinueWith, cancellationToken, continuationOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <returns>A new continuation <see cref="Task{TResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TResult}"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> continuationFunction, object state)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(continuationFunction, state).ContinueWith);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new continuation task.</param>
    /// <returns>A new continuation <see cref="Task{TResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TResult}"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> continuationFunction, object state, CancellationToken cancellationToken)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(continuationFunction, state).ContinueWith, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <returns>A new continuation <see cref="Task{TResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TResult}"/> will not be scheduled for execution until the current task has
    /// completed. If the continuation criteria specified through the <paramref
    /// name="continuationOptions"/> parameter are not met, the continuation task will be canceled
    /// instead of scheduled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> continuationFunction, object state, TaskContinuationOptions continuationOptions)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(continuationFunction, state).ContinueWith, CancellationToken.None, continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task"/> completes.  When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task{TResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TResult}"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> continuationFunction, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(continuationFunction, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new continuation task.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its
    /// execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task{TResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TResult}"/> will not be scheduled for execution until the current task has
    /// completed. If the criteria specified through the <paramref name="continuationOptions"/> parameter
    /// are not met, the continuation task will be canceled instead of scheduled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, object, TResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithOutState<TResult>(continuationFunction, state).ContinueWith, cancellationToken, continuationOptions, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the target Task</typeparam>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <returns>A new continuation <see cref="Task{TNewResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TNewResult}"/> will not be scheduled for execution until the current
    /// task has completed, whether it completes due to running to completion successfully, faulting due
    /// to an unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunction, object state)
    {
        return task.ContinueWith(new ContinueWithInOutState<TResult, TNewResult>(continuationFunction, state).ContinueWith);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the target Task</typeparam>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new task.</param>
    /// <returns>A new continuation <see cref="Task{TNewResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TNewResult}"/> will not be scheduled for execution until the current
    /// task has completed, whether it completes due to running to completion successfully, faulting due
    /// to an unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken)
    {
        return task.ContinueWith(new ContinueWithInOutState<TResult, TNewResult>(continuationFunction, state).ContinueWith, cancellationToken);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the target Task</typeparam>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <returns>A new continuation <see cref="Task{TNewResult}"/>.</returns>
    /// <remarks>
    /// <para>
    /// The returned <see cref="Task{TNewResult}"/> will not be scheduled for execution until the current
    /// task has completed, whether it completes due to running to completion successfully, faulting due
    /// to an unhandled exception, or exiting out early due to being canceled.
    /// </para>
    /// <para>
    /// The <paramref name="continuationFunction"/>, when executed, should return a <see
    /// cref="Task{TNewResult}"/>. This task's completion state will be transferred to the task returned
    /// from the ContinueWith call.
    /// </para>
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskContinuationOptions continuationOptions)
    {
        return task.ContinueWith(new ContinueWithInOutState<TResult, TNewResult>(continuationFunction, state).ContinueWith, CancellationToken.None, continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the target Task</typeparam>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task{TResult}"/> completes.  When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task{TNewResult}"/>.</returns>
    /// <remarks>
    /// The returned <see cref="Task{TNewResult}"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInOutState<TResult, TNewResult>(continuationFunction, state).ContinueWith, CancellationToken.None, TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the target Task</typeparam>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
    /// <param name="task">The target Task</param>
    /// <param name="continuationFunction">
    /// A function to run when the <see cref="Task{TResult}"/> completes. When run, the delegate will be
    /// passed the completed task and the caller-supplied state object as arguments.
    /// </param>
    /// <param name="state">An object representing data to be used by the continuation function.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new task.</param>
    /// <param name="continuationOptions">
    /// Options for when the continuation is scheduled and how it behaves. This includes criteria, such
    /// as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.OnlyOnCanceled">OnlyOnCanceled</see>, as
    /// well as execution options, such as <see
    /// cref="System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously">ExecuteSynchronously</see>.
    /// </param>
    /// <param name="scheduler">
    /// The <see cref="TaskScheduler"/> to associate with the continuation task and to use for its
    /// execution.
    /// </param>
    /// <returns>A new continuation <see cref="Task{TNewResult}"/>.</returns>
    /// <remarks>
    /// <para>
    /// The returned <see cref="Task{TNewResult}"/> will not be scheduled for execution until the current task has
    /// completed, whether it completes due to running to completion successfully, faulting due to an
    /// unhandled exception, or exiting out early due to being canceled.
    /// </para>
    /// <para>
    /// The <paramref name="continuationFunction"/>, when executed, should return a <see cref="Task{TNewResult}"/>.
    /// This task's completion state will be transferred to the task returned from the
    /// ContinueWith call.
    /// </para>
    /// </remarks>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="continuationFunction"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The <paramref name="continuationOptions"/> argument specifies an invalid value for <see
    /// cref="T:System.Threading.Tasks.TaskContinuationOptions">TaskContinuationOptions</see>.
    /// </exception>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="scheduler"/> argument is null.
    /// </exception>
    /// <exception cref="T:System.ObjectDisposedException">The provided <see cref="System.Threading.CancellationToken">CancellationToken</see>
    /// has already been disposed.
    /// </exception>
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ContinueWithInOutState<TResult, TNewResult>(continuationFunction, state).ContinueWith, cancellationToken, continuationOptions, scheduler);
    }

    private sealed class ContinueWithState
    {
        private readonly Action<Task, object> _continuationAction;
        private readonly object _state;

        internal ContinueWithState(Action<Task, object> continuationAction, object state)
        {
            if (continuationAction == null)
                throw new ArgumentNullException(nameof(continuationAction));

            _continuationAction = continuationAction;
            _state = state;
        }

        internal void ContinueWith(Task task)
        {
            _continuationAction(task, _state);
        }
    }

    private sealed class ContinueWithInState<TIn>
    {
        private readonly Action<Task<TIn>, object> _continuationAction;
        private readonly object _state;

        internal ContinueWithInState(Action<Task<TIn>, object> continuationAction, object state)
        {
            if (continuationAction == null)
                throw new ArgumentNullException(nameof(continuationAction));

            _continuationAction = continuationAction;
            _state = state;
        }

        internal void ContinueWith(Task<TIn> task)
        {
            _continuationAction(task, _state);
        }
    }

    private sealed class ContinueWithOutState<TOut>
    {
        private readonly Func<Task, object, TOut> _continuationFunction;
        private readonly object _state;

        internal ContinueWithOutState(Func<Task, object, TOut> continuationFunction, object state)
        {
            if (continuationFunction == null)
                throw new ArgumentNullException(nameof(continuationFunction));

            _continuationFunction = continuationFunction;
            _state = state;
        }

        internal TOut ContinueWith(Task task)
        {
            return _continuationFunction(task, _state);
        }
    }

    private sealed class ContinueWithInOutState<TIn, TOut>
    {
        private readonly Func<Task<TIn>, object, TOut> _continuationFunction;
        private readonly object _state;

        internal ContinueWithInOutState(Func<Task<TIn>, object, TOut> continuationFunction, object state)
        {
            if (continuationFunction == null)
                throw new ArgumentNullException(nameof(continuationFunction));

            _continuationFunction = continuationFunction;
            _state = state;
        }

        internal TOut ContinueWith(Task<TIn> task)
        {
            return _continuationFunction(task, _state);
        }
    }
}
#endif
