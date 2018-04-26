using System;
#if NET35
using System.Collections.Concurrent;
#endif
using System.Collections.Generic;
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
#if NET35
    private static readonly ConcurrentDictionary<WeakCTS, WeakReference> _cancelTimers = new ConcurrentDictionary<WeakCTS, WeakReference>();
#else
    private static readonly ConditionalWeakTable<CancellationTokenSource, Timer> _cancelTimers = new ConditionalWeakTable<CancellationTokenSource, Timer>();
#endif
    private static readonly TimeSpan _timeoutInfinite = new TimeSpan(0, 0, 0, 0, -1);

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
    /// Schedules a Cancel operation on this <see cref="T:System.Threading.CancellationTokenSource"/>.
    /// </summary>
    /// <param name="cancelSource">The <see cref="T:System.Threading.CancellationTokenSource"/> to cancel</param>
    /// <param name="millisecondsDelay">The time span to wait before canceling this <see
    /// cref="T:System.Threading.CancellationTokenSource"/>.
    /// </param>
    /// <exception cref="T:System.ObjectDisposedException">The exception thrown when this <see
    /// cref="T:System.Threading.CancellationTokenSource"/> has been disposed.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The exception thrown when <paramref name="millisecondsDelay"/> is less than -1.
    /// </exception>
    /// <remarks>
    /// <para>
    /// The countdown for the millisecondsDelay starts during this call.  When the millisecondsDelay expires, 
    /// this <see cref="T:System.Threading.CancellationTokenSource"/> is canceled, if it has
    /// not been canceled already.
    /// </para>
    /// <para>
    /// Subsequent calls to CancelAfter will reset the millisecondsDelay for this  
    /// <see cref="T:System.Threading.CancellationTokenSource"/>, if it has not been
    /// canceled already.
    /// </para>
    /// </remarks>
    public static void CancelAfter(this CancellationTokenSource cancelSource, int millisecondsDelay)
    {
        if (millisecondsDelay < Timeout.Infinite)
            throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

        cancelSource.CancelAfter(new TimeSpan(millisecondsDelay * TimeSpan.TicksPerMillisecond));
    }

    /// <summary>
    /// Schedules a Cancel operation on this <see cref="T:System.Threading.CancellationTokenSource"/>.
    /// </summary>
    /// <param name="cancelSource">The <see cref="T:System.Threading.CancellationTokenSource"/> to cancel</param>
    /// <param name="delay">The time span to wait before canceling this <see
    /// cref="T:System.Threading.CancellationTokenSource"/>.
    /// </param>
    /// <exception cref="T:System.ObjectDisposedException">The exception thrown when this <see
    /// cref="T:System.Threading.CancellationTokenSource"/> has been disposed.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// The exception thrown when <paramref name="delay"/> is less than -1 or 
    /// greater than Int32.MaxValue.
    /// </exception>
    /// <remarks>
    /// <para>
    /// The countdown for the delay starts during this call.  When the delay expires, 
    /// this <see cref="T:System.Threading.CancellationTokenSource"/> is canceled, if it has
    /// not been canceled already.
    /// </para>
    /// <para>
    /// Subsequent calls to CancelAfter will reset the delay for this  
    /// <see cref="T:System.Threading.CancellationTokenSource"/>, if it has not been
    /// canceled already.
    /// </para>
    /// </remarks>
    public static void CancelAfter(this CancellationTokenSource cancelSource, TimeSpan delay)
    {
        if (cancelSource == null)
            throw new ArgumentNullException(nameof(cancelSource));

        if (delay < _timeoutInfinite)
            throw new ArgumentOutOfRangeException(nameof(delay));

        if (cancelSource.IsCancellationRequested)
            return;

        Timer myTimer = null;

        // CTS claims it's thread-safe for all methods, so we should be the same.
        // If someone calls CancelAfter concurrently for the same CTS, we won't explode or cause a memory leak
        while (!_cancelTimers.TryGetTimer(cancelSource, out myTimer))
        {
            // An active timer doesn't hold a strong reference to itself, so adding the CTS as state won't hold it alive
            myTimer = new Timer(OnCancelAfterTimer, cancelSource, Timeout.Infinite, Timeout.Infinite);

            if (_cancelTimers.TryAddTimer(cancelSource, myTimer))
                break;

            // TryAddTimer can only fail if a Timer was created concurrently. Since we never remove them, TryGetTimer is guaranteed to succeed
            // Thus, we can dispose of the new Timer we just created and loop back.
            // If a thread abort or other exception occurs here, we leave the orphan timer to be GC'ed
            myTimer.Dispose();
        }

        try
        {
            // Either set the duration on the new timer, or reset the duration on an existing timer
            myTimer.Change(delay, _timeoutInfinite);
        }
        catch (ObjectDisposedException)
        {
        }
    }

    private static void OnCancelAfterTimer(object state)
    {
        var cancelSource = (CancellationTokenSource)state;

        if (!_cancelTimers.TryRemoveTimer(cancelSource, out var oldTimer))
            return;

        oldTimer.Dispose();

        try
        {
            cancelSource.Cancel();
        }
        catch (ObjectDisposedException) // If the cancellation token has been disposed of, ignore the exception
        {
        }
    }

#if NET35
    private struct WeakCTS : IEquatable<WeakCTS>
    {
        private readonly int _hashCode;

        internal WeakCTS(CancellationTokenSource cts)
        {
            _hashCode = cts.GetHashCode();
            CTS = new WeakReference(cts);
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }

        public override bool Equals(object obj)
        {
            return obj is WeakCTS Value && Equals(Value);
        }

        public bool Equals(WeakCTS other)
        {
            // In the case our CTS is no longer alive, this will still work when doing dictionary lookups. Null matches null
            return _hashCode == other._hashCode && ReferenceEquals(CTS.Target, other.CTS.Target);
        }

        internal WeakReference CTS { get; }

        public static implicit operator WeakCTS(CancellationTokenSource cts)
        {
            return new WeakCTS(cts);
        }
    }

    private static bool TryAddTimer(this ConcurrentDictionary<WeakCTS, WeakReference> table, CancellationTokenSource cancelSource, Timer timer)
    {
        if (!table.TryAdd(cancelSource, new WeakReference(timer)))
            return false;

        // Since we use weak-references to the Timer, we need to ensure it doesn't get garbage collected until the CTS does.
        // The CancellationToken registration works - we just stick it in the state property, and it'll hold a strong reference for us.
        cancelSource.Token.Register((state) => { }, timer);

        // Cleanup any dead CTS->Timer links
        foreach (var key in _cancelTimers.Keys)
        {
            if (!key.CTS.IsAlive)
                _cancelTimers.TryRemove(key, out _);
        }

        return true;
    }

    private static bool TryGetTimer(this ConcurrentDictionary<WeakCTS, WeakReference> table, CancellationTokenSource cancelSource, out Timer timer)
    {
        if (!table.TryGetValue(cancelSource, out var weakReference))
        {
            timer = null;
            return false;
        }

        timer = (Timer)weakReference.Target;

        return timer != null; // Could return false if the CTS was cancelled concurrently and our timer triggered
    }

    private static bool TryRemoveTimer(this ConcurrentDictionary<WeakCTS, WeakReference> table, CancellationTokenSource cancelSource, out Timer timer)
    {
        if (!table.TryRemove(cancelSource, out var weakReference))
        {
            timer = null;
            return false;
        }

        timer = (Timer)weakReference.Target;

        return timer != null; // Should always return true, but to be safe we check
    }
#else
    private static bool TryAddTimer(this ConditionalWeakTable<CancellationTokenSource, Timer> table, CancellationTokenSource cancelSource, Timer timer)
    {
        try
        {
            table.Add(cancelSource, timer);

            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
    
    private static bool TryGetTimer(this ConditionalWeakTable<CancellationTokenSource, Timer> table, CancellationTokenSource cancelSource, out Timer timer)
    {
        return table.TryGetValue(cancelSource, out timer);
    }

    private static bool TryRemoveTimer(this ConditionalWeakTable<CancellationTokenSource, Timer> table, CancellationTokenSource cancelSource, out Timer timer)
    {
        if (!table.TryGetValue(cancelSource, out timer))
            return false;
        
        table.Remove(cancelSource);
        return true;
    }
#endif
}
// ReSharper restore CheckNamespace
