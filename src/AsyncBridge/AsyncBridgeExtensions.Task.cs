#if NET40 || PORTABLE
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

public static partial class AsyncBridgeExtensions
{
    #region From Task.cs

    #region Await Support

    /// <summary>Gets an awaiter used to await this <see cref="System.Threading.Tasks.Task"/>.</summary>
    /// <returns>An awaiter instance.</returns>
    /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
    public static TaskAwaiter GetAwaiter(this Task task)
    {
        return new TaskAwaiter(task);
    }

    /// <summary>Configures an awaiter used to await this <see cref="System.Threading.Tasks.Task"/>.</summary>
    /// <param name="continueOnCapturedContext">
    /// true to attempt to marshal the continuation back to the original context captured; otherwise, false.
    /// </param>
    /// <returns>An object used to await this task.</returns>
    public static ConfiguredTaskAwaitable ConfigureAwait(this Task task, bool continueOnCapturedContext)
    {
        return new ConfiguredTaskAwaitable(task, continueOnCapturedContext);
    }

    #endregion

    #region Continuation methods

    #region Action<Task, Object> continuation

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
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
    public static Task ContinueWith(this Task task, Action<Task, Object> continuationAction, Object state)
    {
        return ContinueWith(task, continuationAction, state, default(CancellationToken), TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
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
    public static Task ContinueWith(this Task task, Action<Task, Object> continuationAction, Object state, CancellationToken cancellationToken)
    {
        return ContinueWith(task, continuationAction, state, cancellationToken, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
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
    public static Task ContinueWith(this Task task, Action<Task, Object> continuationAction, Object state, TaskScheduler scheduler)
    {
        return ContinueWith(task, continuationAction, state, default(CancellationToken), TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
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
    public static Task ContinueWith(this Task task, Action<Task, Object> continuationAction, Object state, TaskContinuationOptions continuationOptions)
    {
        return ContinueWith(task, continuationAction, state, default(CancellationToken), continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
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
    public static Task ContinueWith(this Task task, Action<Task, Object> continuationAction, Object state, CancellationToken cancellationToken,
                             TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ActionClosure<Task>(continuationAction, state).Invoke, cancellationToken, continuationOptions, scheduler);
    }

    #endregion

    #region Func<Task, Object, TResult> continuation

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, Object, TResult> continuationFunction, Object state)
    {
        return ContinueWith(task, continuationFunction, state, default(CancellationToken), TaskContinuationOptions.None,
            TaskScheduler.Current);
    }


    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, Object, TResult> continuationFunction, Object state, CancellationToken cancellationToken)
    {
        return ContinueWith(task, continuationFunction, state, cancellationToken, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, Object, TResult> continuationFunction, Object state, TaskScheduler scheduler)
    {
        return ContinueWith(task, continuationFunction, state, default(CancellationToken), TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, Object, TResult> continuationFunction, Object state, TaskContinuationOptions continuationOptions)
    {
        return ContinueWith(task, continuationFunction, state, default(CancellationToken), continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task"/> completes.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, Object, TResult> continuationFunction, Object state, CancellationToken cancellationToken,
                                               TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new FuncClosure<Task, TResult>(continuationFunction, state).Invoke, cancellationToken, continuationOptions, scheduler);
    }

    #endregion

    #endregion

    #endregion

    #region From future.cs

    #region Await Support

    /// <summary>Gets an awaiter used to await this <see cref="System.Threading.Tasks.Task{TResult}"/>.</summary>
    /// <returns>An awaiter instance.</returns>
    /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
    public static TaskAwaiter<TResult> GetAwaiter<TResult>(this Task<TResult> task)
    {
        return new TaskAwaiter<TResult>(task);
    }

    /// <summary>Configures an awaiter used to await this <see cref="System.Threading.Tasks.Task{TResult}"/>.</summary>
    /// <param name="continueOnCapturedContext">
    /// true to attempt to marshal the continuation back to the original context captured; otherwise, false.
    /// </param>
    /// <returns>An object used to await this task.</returns>
    public static ConfiguredTaskAwaitable<TResult> ConfigureAwait<TResult>(this Task<TResult> task, bool continueOnCapturedContext)
    {
        return new ConfiguredTaskAwaitable<TResult>(task, continueOnCapturedContext);
    }

    #endregion

    #region Continuation methods

    #region Action<Task<TResult>, Object> continuations

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
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
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, Object> continuationAction, Object state)
    {
        return ContinueWith(task, continuationAction, state, default(CancellationToken), TaskContinuationOptions.None, TaskScheduler.Current);
    }


    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
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
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, Object> continuationAction, Object state, CancellationToken cancellationToken)
    {
        return ContinueWith(task, continuationAction, state, cancellationToken, TaskContinuationOptions.None, TaskScheduler.Current);
    }


    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
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
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, Object> continuationAction, Object state, TaskScheduler scheduler)
    {
        return ContinueWith(task, continuationAction, state, default(CancellationToken), TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
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
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, Object> continuationAction, Object state, TaskContinuationOptions continuationOptions)
    {
        return ContinueWith(task, continuationAction, state, default(CancellationToken), continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
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
    public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>, Object> continuationAction, Object state, CancellationToken cancellationToken,
                             TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new ActionClosure<Task<TResult>>(continuationAction, state).Invoke, cancellationToken, continuationOptions, scheduler);
    }

    #endregion

    #region Func<Task<TResult>, Object, TNewResult> continuations

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, Object, TNewResult> continuationFunction, Object state)
    {
        return ContinueWith(task, continuationFunction, state, default(CancellationToken), TaskContinuationOptions.None, TaskScheduler.Current);
    }


    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, Object, TNewResult> continuationFunction, Object state,
        CancellationToken cancellationToken)
    {
        return ContinueWith(task, continuationFunction, state, cancellationToken, TaskContinuationOptions.None, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, Object, TNewResult> continuationFunction, Object state,
        TaskScheduler scheduler)
    {
        return ContinueWith(task, continuationFunction, state, default(CancellationToken), TaskContinuationOptions.None, scheduler);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, Object, TNewResult> continuationFunction, Object state,
        TaskContinuationOptions continuationOptions)
    {
        return ContinueWith(task, continuationFunction, state, default(CancellationToken), continuationOptions, TaskScheduler.Current);
    }

    /// <summary>
    /// Creates a continuation that executes when the target <see cref="Task{TResult}"/> completes.
    /// </summary>
    /// <typeparam name="TNewResult">
    /// The type of the result produced by the continuation.
    /// </typeparam>
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
    public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, Object, TNewResult> continuationFunction, Object state,
        CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
        return task.ContinueWith(new FuncClosure<Task<TResult>, TNewResult>(continuationFunction, state).Invoke, cancellationToken, continuationOptions, scheduler);
    }

    #endregion

    #endregion

    #endregion

    private sealed class ActionClosure<TTask>
    {
        private readonly Action<TTask, object> action;
        private readonly object state;

        public ActionClosure(Action<TTask, object> action, object state)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.state = state;
        }

        public void Invoke(TTask task)
        {
            action.Invoke(task, state);
        }
    }

    private sealed class FuncClosure<TTask, TResult>
    {
        private readonly Func<TTask, object, TResult> func;
        private readonly object state;

        public FuncClosure(Func<TTask, object, TResult> func, object state)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            this.state = state;
        }

        public TResult Invoke(TTask task)
        {
            return func.Invoke(task, state);
        }
    }
}
#endif
