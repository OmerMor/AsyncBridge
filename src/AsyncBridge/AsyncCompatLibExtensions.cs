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
    /// Causes a cancellation token source to cancel after a specified time
    /// </summary>
    /// <param name="cancelSource">The cancellation token source to cancel</param>
    /// <param name="millisecondsDelay">The time in milliseconds to wait before cancellation</param>
    public static void CancelAfter(this CancellationTokenSource cancelSource, int millisecondsDelay)
    {
        cancelSource.CancelAfter(new TimeSpan(millisecondsDelay * TimeSpan.TicksPerMillisecond));
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
