// Name:       AsyncBridge
// Public key: ACQAAASAAACUAAAABgIAAAAkAABSU0ExAAQAAAEAAQCLFl3K4YXiNrRI+T6dQfJ73C164NxT1pBidQ9sJZMSKVrEBhi53LnGTBdJZj0s83kCjfQ8tdBvxM4IDe7zH3TxhJDdo40tiZ4ZFOwnDv00373pftuR6JDZ3J3AIeWuhsFhxaofTb5UDfwsMW6M8ypuaTJpFG6v9EaSKJ9hajJPoA==

namespace System
{
    [System.Diagnostics.DebuggerDisplay("Count = {InnerExceptionCount}")]
    public class AggregateException : Exception
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Exception> InnerExceptions { get; }

        public override string Message { get; }

        public AggregateException();

        public AggregateException(string message);

        public AggregateException(string message, Exception innerException);

        public AggregateException(System.Collections.Generic.IEnumerable<Exception> innerExceptions);

        public AggregateException(params Exception[] innerExceptions);

        public AggregateException(string message, System.Collections.Generic.IEnumerable<Exception> innerExceptions);

        public AggregateException(string message, params Exception[] innerExceptions);

        protected AggregateException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);

        public AggregateException Flatten();

        public override Exception GetBaseException();

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);

        public void Handle(Func<Exception, bool> predicate);

        public override string ToString();
    }

    public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
}
namespace System.Runtime.CompilerServices
{
    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class AsyncStateMachineAttribute : StateMachineAttribute
    {
        public AsyncStateMachineAttribute(System.Type stateMachineType);
    }

    public struct AsyncTaskMethodBuilder
    {
        public System.Threading.Tasks.Task Task { get; }

        public static AsyncTaskMethodBuilder Create();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void SetException(System.Exception exception);

        public void SetResult();

        public void SetStateMachine(IAsyncStateMachine stateMachine);

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
    }

    public struct AsyncTaskMethodBuilder<TResult>
    {
        public System.Threading.Tasks.Task<TResult> Task { get; }

        public static AsyncTaskMethodBuilder<TResult> Create();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;

        [System.Security.SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void SetException(System.Exception exception);

        public void SetResult(TResult result);

        public void SetStateMachine(IAsyncStateMachine stateMachine);

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
    }

    public struct AsyncVoidMethodBuilder
    {
        public static AsyncVoidMethodBuilder Create();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;

        [System.Security.SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void SetException(System.Exception exception);

        public void SetResult();

        public void SetStateMachine(IAsyncStateMachine stateMachine);

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
    }

    public readonly struct ConfiguredTaskAwaitable
    {
        public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter();

        public readonly struct ConfiguredTaskAwaiter
        {
            public bool IsCompleted { get; }

            public void GetResult();

            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }

    public readonly struct ConfiguredTaskAwaitable<TResult>
    {
        public ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter GetAwaiter();

        public readonly struct ConfiguredTaskAwaiter
        {
            public bool IsCompleted { get; }

            public TResult GetResult();

            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }

    public interface IAsyncStateMachine
    {
        void MoveNext();

        void SetStateMachine(IAsyncStateMachine stateMachine);
    }

    public interface ICriticalNotifyCompletion : INotifyCompletion
    {
        [System.Security.SecurityCritical]
        void UnsafeOnCompleted(System.Action continuation);
    }

    public interface INotifyCompletion
    {
        void OnCompleted(System.Action continuation);
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class IteratorStateMachineAttribute : StateMachineAttribute
    {
        public IteratorStateMachineAttribute(System.Type stateMachineType);
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class StateMachineAttribute : System.Attribute
    {
        public System.Type StateMachineType { get; }

        public StateMachineAttribute(System.Type stateMachineType);
    }

    public readonly struct TaskAwaiter
    {
        public bool IsCompleted { get; }

        public void GetResult();

        public void OnCompleted(System.Action continuation);

        [System.Security.SecurityCritical]
        public void UnsafeOnCompleted(System.Action continuation);
    }

    public readonly struct TaskAwaiter<TResult>
    {
        public bool IsCompleted { get; }

        public TResult GetResult();

        public void OnCompleted(System.Action continuation);

        [System.Security.SecurityCritical]
        public void UnsafeOnCompleted(System.Action continuation);
    }

    public readonly struct YieldAwaitable
    {
        public YieldAwaitable.YieldAwaiter GetAwaiter();

        public readonly struct YieldAwaiter
        {
            public bool IsCompleted { get; }

            public void GetResult();

            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }
}
namespace System.Runtime.ExceptionServices
{
    public sealed class ExceptionDispatchInfo
    {
        public System.Exception SourceException { get; }

        public static ExceptionDispatchInfo Capture(System.Exception source);

        public static void Throw(System.Exception source);

        public void Throw();
    }
}
namespace System.Threading
{
    [System.Diagnostics.DebuggerDisplay("IsCancellationRequested = {IsCancellationRequested}")]
    public readonly struct CancellationToken
    {
        public static CancellationToken None { get; }

        public bool CanBeCanceled { get; }

        public bool IsCancellationRequested { get; }

        public WaitHandle WaitHandle { get; }

        public CancellationToken(bool canceled);

        public bool Equals(CancellationToken other);

        public override bool Equals(object other);

        public override int GetHashCode();

        public CancellationTokenRegistration Register(System.Action callback);

        public CancellationTokenRegistration Register(System.Action callback, bool useSynchronizationContext);

        public CancellationTokenRegistration Register(System.Action<object> callback, object state);

        public CancellationTokenRegistration Register(System.Action<object> callback, object state, bool useSynchronizationContext);

        public void ThrowIfCancellationRequested();

        public static bool operator ==(CancellationToken left, CancellationToken right);

        public static bool operator !=(CancellationToken left, CancellationToken right);
    }

    public readonly struct CancellationTokenRegistration
    {
        public CancellationToken Token { get; }

        public void Dispose();

        public override bool Equals(object obj);

        public bool Equals(CancellationTokenRegistration other);

        public override int GetHashCode();

        public static bool operator ==(CancellationTokenRegistration left, CancellationTokenRegistration right);

        public static bool operator !=(CancellationTokenRegistration left, CancellationTokenRegistration right);
    }

    public class CancellationTokenSource : System.IDisposable
    {
        public bool IsCancellationRequested { get; }

        public CancellationToken Token { get; }

        public static CancellationTokenSource CreateLinkedTokenSource(CancellationToken token1, CancellationToken token2);

        public static CancellationTokenSource CreateLinkedTokenSource(params CancellationToken[] tokens);

        public CancellationTokenSource();

        public CancellationTokenSource(System.TimeSpan delay);

        public CancellationTokenSource(int millisecondsDelay);

        public void Cancel();

        public void Cancel(bool throwOnFirstException);

        public void CancelAfter(System.TimeSpan delay);

        public void CancelAfter(int millisecondsDelay);

        public void Dispose();

        protected virtual void Dispose(bool disposing);
    }

    [System.Diagnostics.DebuggerDisplay("Initial Count={InitialCount}, Current Count={CurrentCount}")]
    public class CountdownEvent : System.IDisposable
    {
        public int CurrentCount { get; }

        public int InitialCount { get; }

        public bool IsSet { get; }

        public WaitHandle WaitHandle { get; }

        public CountdownEvent(int initialCount);

        public void AddCount();

        public void AddCount(int signalCount);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public void Reset();

        public void Reset(int count);

        public bool Signal();

        public bool Signal(int signalCount);

        public bool TryAddCount();

        public bool TryAddCount(int signalCount);

        public void Wait();

        public void Wait(CancellationToken cancellationToken);

        public bool Wait(System.TimeSpan timeout);

        public bool Wait(System.TimeSpan timeout, CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
    }

    public static class LazyInitializer
    {
        public static T EnsureInitialized<T>(ref T target) where T : class;

        public static T EnsureInitialized<T>(ref T target, System.Func<T> valueFactory) where T : class;

        public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock);

        public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock, System.Func<T> valueFactory);

        public static T EnsureInitialized<T>(ref T target, ref object syncLock, System.Func<T> valueFactory) where T : class;
    }

    [System.Diagnostics.DebuggerDisplay("Set = {IsSet}")]
    public class ManualResetEventSlim : System.IDisposable
    {
        public bool IsSet { get; }

        public int SpinCount { get; }

        public WaitHandle WaitHandle { get; }

        public ManualResetEventSlim();

        public ManualResetEventSlim(bool initialState);

        public ManualResetEventSlim(bool initialState, int spinCount);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public void Reset();

        public void Set();

        public void Wait();

        public void Wait(CancellationToken cancellationToken);

        public bool Wait(System.TimeSpan timeout);

        public bool Wait(System.TimeSpan timeout, CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(SpinLock.SystemThreading_SpinLockDebugView))]
    [System.Diagnostics.DebuggerDisplay("IsHeld = {IsHeld}")]
    public struct SpinLock
    {
        public bool IsHeld { get; }

        public bool IsHeldByCurrentThread { get; }

        public bool IsThreadOwnerTrackingEnabled { get; }

        public SpinLock(bool enableThreadOwnerTracking);

        public void Enter(ref bool lockTaken);

        public void Exit();

        public void Exit(bool useMemoryBarrier);

        public void TryEnter(ref bool lockTaken);

        public void TryEnter(System.TimeSpan timeout, ref bool lockTaken);

        public void TryEnter(int millisecondsTimeout, ref bool lockTaken);
    }

    public struct SpinWait
    {
        public int Count { get; }

        public bool NextSpinWillYield { get; }

        public static void SpinUntil(System.Func<bool> condition);

        public static bool SpinUntil(System.Func<bool> condition, System.TimeSpan timeout);

        public static bool SpinUntil(System.Func<bool> condition, int millisecondsTimeout);

        public void Reset();

        public void SpinOnce();
    }

    public static class Volatile
    {
        public static bool Read(ref bool location);

        [System.CLSCompliant(false)]
        public static sbyte Read(ref sbyte location);

        public static byte Read(ref byte location);

        public static short Read(ref short location);

        [System.CLSCompliant(false)]
        public static ushort Read(ref ushort location);

        public static int Read(ref int location);

        [System.CLSCompliant(false)]
        public static uint Read(ref uint location);

        public static long Read(ref long location);

        [System.CLSCompliant(false)]
        public static ulong Read(ref ulong location);

        public static System.IntPtr Read(ref System.IntPtr location);

        [System.CLSCompliant(false)]
        public static System.UIntPtr Read(ref System.UIntPtr location);

        public static float Read(ref float location);

        public static double Read(ref double location);

        public static T Read<T>(ref T location) where T : class;

        public static void Write(ref bool location, bool value);

        [System.CLSCompliant(false)]
        public static void Write(ref sbyte location, sbyte value);

        public static void Write(ref byte location, byte value);

        public static void Write(ref short location, short value);

        [System.CLSCompliant(false)]
        public static void Write(ref ushort location, ushort value);

        public static void Write(ref int location, int value);

        [System.CLSCompliant(false)]
        public static void Write(ref uint location, uint value);

        public static void Write(ref long location, long value);

        [System.CLSCompliant(false)]
        public static void Write(ref ulong location, ulong value);

        public static void Write(ref System.IntPtr location, System.IntPtr value);

        [System.CLSCompliant(false)]
        public static void Write(ref System.UIntPtr location, System.UIntPtr value);

        public static void Write(ref float location, float value);

        public static void Write(ref double location, double value);

        public static void Write<T>(ref T location, T value) where T : class;
    }
}
namespace System.Threading.Tasks
{
    [System.Diagnostics.DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskDebugView))]
    [System.Diagnostics.DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}")]
    public class Task : System.IAsyncResult, System.IDisposable
    {
        public static Task CompletedTask { get; }

        public static int? CurrentId { get; }

        public static TaskFactory Factory { get; }

        public object AsyncState { get; }

        public TaskCreationOptions CreationOptions { get; }

        public System.AggregateException Exception { get; }

        public int Id { get; }

        public bool IsCanceled { get; }

        public bool IsCompleted { get; }

        public bool IsCompletedSuccessfully { get; }

        public bool IsFaulted { get; }

        public TaskStatus Status { get; }

        public static Task Delay(System.TimeSpan delay);

        public static Task Delay(System.TimeSpan delay, System.Threading.CancellationToken cancellationToken);

        public static Task Delay(int millisecondsDelay);

        public static Task Delay(int millisecondsDelay, System.Threading.CancellationToken cancellationToken);

        public static Task FromCanceled(System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> FromCanceled<TResult>(System.Threading.CancellationToken cancellationToken);

        public static Task FromException(System.Exception exception);

        public static Task<TResult> FromException<TResult>(System.Exception exception);

        public static Task<TResult> FromResult<TResult>(TResult result);

        public static Task Run(System.Action action);

        public static Task Run(System.Action action, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> Run<TResult>(System.Func<TResult> function);

        public static Task<TResult> Run<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public static Task Run(System.Func<Task> function);

        public static Task Run(System.Func<Task> function, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> Run<TResult>(System.Func<Task<TResult>> function);

        public static Task<TResult> Run<TResult>(System.Func<Task<TResult>> function, System.Threading.CancellationToken cancellationToken);

        public static void WaitAll(params Task[] tasks);

        public static bool WaitAll(Task[] tasks, System.TimeSpan timeout);

        public static bool WaitAll(Task[] tasks, int millisecondsTimeout);

        public static void WaitAll(Task[] tasks, System.Threading.CancellationToken cancellationToken);

        public static bool WaitAll(Task[] tasks, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public static int WaitAny(params Task[] tasks);

        public static int WaitAny(Task[] tasks, System.TimeSpan timeout);

        public static int WaitAny(Task[] tasks, System.Threading.CancellationToken cancellationToken);

        public static int WaitAny(Task[] tasks, int millisecondsTimeout);

        public static int WaitAny(Task[] tasks, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public static Task WhenAll(System.Collections.Generic.IEnumerable<Task> tasks);

        public static Task WhenAll(params Task[] tasks);

        public static Task<TResult[]> WhenAll<TResult>(System.Collections.Generic.IEnumerable<Task<TResult>> tasks);

        public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);

        public static Task<Task> WhenAny(params Task[] tasks);

        public static Task<Task> WhenAny(System.Collections.Generic.IEnumerable<Task> tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(System.Collections.Generic.IEnumerable<Task<TResult>> tasks);

        public static System.Runtime.CompilerServices.YieldAwaitable Yield();

        public Task(System.Action action);

        public Task(System.Action action, System.Threading.CancellationToken cancellationToken);

        public Task(System.Action action, TaskCreationOptions creationOptions);

        public Task(System.Action action, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public Task(System.Action<object> action, object state);

        public Task(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken);

        public Task(System.Action<object> action, object state, TaskCreationOptions creationOptions);

        public Task(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public System.Runtime.CompilerServices.ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext);

        public Task ContinueWith(System.Action<Task> continuationAction);

        public Task ContinueWith(System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task> continuationAction, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public System.Runtime.CompilerServices.TaskAwaiter GetAwaiter();

        public void RunSynchronously();

        public void RunSynchronously(TaskScheduler scheduler);

        public void Start();

        public void Start(TaskScheduler scheduler);

        public void Wait();

        public bool Wait(System.TimeSpan timeout);

        public void Wait(System.Threading.CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(SystemThreadingTasks_FutureDebugView<>))]
    [System.Diagnostics.DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}, Result = {DebuggerDisplayResultDescription}")]
    public class Task<TResult> : Task
    {
        public static TaskFactory<TResult> Factory { get; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public TResult Result { get; }

        public Task(System.Func<TResult> function);

        public Task(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public Task(System.Func<TResult> function, TaskCreationOptions creationOptions);

        public Task(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public Task(System.Func<object, TResult> function, object state);

        public Task(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken);

        public Task(System.Func<object, TResult> function, object state, TaskCreationOptions creationOptions);

        public Task(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public System.Runtime.CompilerServices.ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public System.Runtime.CompilerServices.TaskAwaiter<TResult> GetAwaiter();
    }

    public class TaskCanceledException : System.OperationCanceledException
    {
        public Task Task { get; }

        public TaskCanceledException();

        public TaskCanceledException(string message);

        public TaskCanceledException(string message, System.Exception innerException);

        public TaskCanceledException(string message, System.Exception innerException, System.Threading.CancellationToken token);

        public TaskCanceledException(Task task);

        protected TaskCanceledException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }

    public class TaskCompletionSource<TResult>
    {
        public Task<TResult> Task { get; }

        public TaskCompletionSource();

        public TaskCompletionSource(TaskCreationOptions creationOptions);

        public TaskCompletionSource(object state);

        public TaskCompletionSource(object state, TaskCreationOptions creationOptions);

        public void SetCanceled();

        public void SetException(System.Exception exception);

        public void SetException(System.Collections.Generic.IEnumerable<System.Exception> exceptions);

        public void SetResult(TResult result);

        public bool TrySetCanceled();

        public bool TrySetCanceled(System.Threading.CancellationToken cancellationToken);

        public bool TrySetException(System.Exception exception);

        public bool TrySetException(System.Collections.Generic.IEnumerable<System.Exception> exceptions);

        public bool TrySetResult(TResult result);
    }

    [System.Flags]
    public enum TaskContinuationOptions : int
    {
        None = 0,
        PreferFairness = 1,
        LongRunning = 2,
        AttachedToParent = 4,
        DenyChildAttach = 8,
        HideScheduler = 16,
        LazyCancellation = 32,
        RunContinuationsAsynchronously = 64,
        NotOnRanToCompletion = 65_536,
        NotOnFaulted = 131_072,
        OnlyOnCanceled = 196_608,
        NotOnCanceled = 262_144,
        OnlyOnFaulted = 327_680,
        OnlyOnRanToCompletion = 393_216,
        ExecuteSynchronously = 524_288
    }

    [System.Flags]
    public enum TaskCreationOptions : int
    {
        None = 0,
        PreferFairness = 1,
        LongRunning = 2,
        AttachedToParent = 4,
        DenyChildAttach = 8,
        HideScheduler = 16,
        RunContinuationsAsynchronously = 64
    }

    public static class TaskExtensions
    {
        public static Task Unwrap(this Task<Task> task);

        public static Task<TResult> Unwrap<TResult>(this Task<Task<TResult>> task);
    }

    public class TaskFactory
    {
        public System.Threading.CancellationToken CancellationToken { get; }

        public TaskContinuationOptions ContinuationOptions { get; }

        public TaskCreationOptions CreationOptions { get; }

        public TaskScheduler Scheduler { get; }

        public TaskFactory();

        public TaskFactory(System.Threading.CancellationToken cancellationToken);

        public TaskFactory(TaskScheduler scheduler);

        public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions);

        public TaskFactory(System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task FromAsync(System.IAsyncResult asyncResult, System.Action<System.IAsyncResult> endMethod);

        public Task FromAsync(System.IAsyncResult asyncResult, System.Action<System.IAsyncResult> endMethod, TaskCreationOptions creationOptions);

        public Task FromAsync(System.IAsyncResult asyncResult, System.Action<System.IAsyncResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, object state);

        public Task FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, object state, TaskCreationOptions creationOptions);

        public Task FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, object state);

        public Task FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);

        public Task FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state);

        public Task FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);

        public Task FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);

        public Task FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TResult>(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod);

        public Task<TResult> FromAsync<TResult>(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TResult>(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> FromAsync<TResult>(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state);

        public Task<TResult> FromAsync<TResult>(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TResult>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state);

        public Task<TResult> FromAsync<TArg1, TResult>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2, TResult>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state);

        public Task<TResult> FromAsync<TArg1, TArg2, TResult>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);

        public Task StartNew(System.Action action);

        public Task StartNew(System.Action action, System.Threading.CancellationToken cancellationToken);

        public Task StartNew(System.Action action, TaskCreationOptions creationOptions);

        public Task StartNew(System.Action action, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task StartNew(System.Action<object> action, object state);

        public Task StartNew(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken);

        public Task StartNew(System.Action<object> action, object state, TaskCreationOptions creationOptions);

        public Task StartNew(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
    }

    public class TaskFactory<TResult>
    {
        public System.Threading.CancellationToken CancellationToken { get; }

        public TaskContinuationOptions ContinuationOptions { get; }

        public TaskCreationOptions CreationOptions { get; }

        public TaskScheduler Scheduler { get; }

        public TaskFactory();

        public TaskFactory(System.Threading.CancellationToken cancellationToken);

        public TaskFactory(TaskScheduler scheduler);

        public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions);

        public TaskFactory(System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> FromAsync(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod);

        public Task<TResult> FromAsync(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state);

        public Task<TResult> FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state);

        public Task<TResult> FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state);

        public Task<TResult> FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew(System.Func<TResult> function);

        public Task<TResult> StartNew(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew(System.Func<TResult> function, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
    }

    [System.Diagnostics.DebuggerDisplay("Id={Id}")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(TaskScheduler.SystemThreadingTasks_TaskSchedulerDebugView))]
    public abstract class TaskScheduler
    {
        public static TaskScheduler Current { get; }

        public static TaskScheduler Default { get; }

        public int Id { get; }

        public virtual int MaximumConcurrencyLevel { get; }

        public static event System.EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException;

        public static TaskScheduler FromCurrentSynchronizationContext();

        protected TaskScheduler();

        protected abstract System.Collections.Generic.IEnumerable<Task> GetScheduledTasks();

        protected abstract void QueueTask(Task task);

        protected virtual bool TryDequeue(Task task);

        protected bool TryExecuteTask(Task task);

        protected abstract bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued);
    }

    public class TaskSchedulerException : System.Exception
    {
        public TaskSchedulerException();

        public TaskSchedulerException(string message);

        public TaskSchedulerException(System.Exception innerException);

        public TaskSchedulerException(string message, System.Exception innerException);

        protected TaskSchedulerException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }

    public enum TaskStatus : int
    {
        Created = 0,
        WaitingForActivation = 1,
        WaitingToRun = 2,
        Running = 3,
        WaitingForChildrenToComplete = 4,
        RanToCompletion = 5,
        Canceled = 6,
        Faulted = 7
    }

    public class UnobservedTaskExceptionEventArgs : System.EventArgs
    {
        public System.AggregateException Exception { get; }

        public bool Observed { get; }

        public UnobservedTaskExceptionEventArgs(System.AggregateException exception);

        public void SetObserved();
    }
}
