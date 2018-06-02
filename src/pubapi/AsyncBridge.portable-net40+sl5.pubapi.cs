// Name:       AsyncBridge
// Public key: ACQAAASAAACUAAAABgIAAAAkAABSU0ExAAQAAAEAAQCLFl3K4YXiNrRI+T6dQfJ73C164NxT1pBidQ9sJZMSKVrEBhi53LnGTBdJZj0s83kCjfQ8tdBvxM4IDe7zH3TxhJDdo40tiZ4ZFOwnDv00373pftuR6JDZ3J3AIeWuhsFhxaofTb5UDfwsMW6M8ypuaTJpFG6v9EaSKJ9hajJPoA==

public static class AsyncCompatLibExtensions
{
    public static System.Runtime.CompilerServices.ConfiguredTaskAwaitable<TResult> ConfigureAwait<TResult>(this System.Threading.Tasks.Task<TResult> task, bool continueOnCapturedContext);

    public static System.Runtime.CompilerServices.ConfiguredTaskAwaitable ConfigureAwait(this System.Threading.Tasks.Task task, bool continueOnCapturedContext);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> continuationAction, object state);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> continuationAction, object state, System.Threading.Tasks.TaskContinuationOptions continuationOptions);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> continuationAction, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions continuationOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task ContinueWith<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Action<System.Threading.Tasks.Task<TResult>, object> continuationAction, object state);

    public static System.Threading.Tasks.Task ContinueWith<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Action<System.Threading.Tasks.Task<TResult>, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken);

    public static System.Threading.Tasks.Task ContinueWith<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Action<System.Threading.Tasks.Task<TResult>, object> continuationAction, object state, System.Threading.Tasks.TaskContinuationOptions continuationOptions);

    public static System.Threading.Tasks.Task ContinueWith<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Action<System.Threading.Tasks.Task<TResult>, object> continuationAction, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task ContinueWith<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Action<System.Threading.Tasks.Task<TResult>, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions continuationOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> continuationFunction, object state);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> continuationFunction, object state, System.Threading.Tasks.TaskContinuationOptions continuationOptions);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> continuationFunction, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions continuationOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TNewResult> ContinueWith<TResult, TNewResult>(this System.Threading.Tasks.Task<TResult> task, System.Func<System.Threading.Tasks.Task<TResult>, object, TNewResult> continuationFunction, object state);

    public static System.Threading.Tasks.Task<TNewResult> ContinueWith<TResult, TNewResult>(this System.Threading.Tasks.Task<TResult> task, System.Func<System.Threading.Tasks.Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken);

    public static System.Threading.Tasks.Task<TNewResult> ContinueWith<TResult, TNewResult>(this System.Threading.Tasks.Task<TResult> task, System.Func<System.Threading.Tasks.Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.Tasks.TaskContinuationOptions continuationOptions);

    public static System.Threading.Tasks.Task<TNewResult> ContinueWith<TResult, TNewResult>(this System.Threading.Tasks.Task<TResult> task, System.Func<System.Threading.Tasks.Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TNewResult> ContinueWith<TResult, TNewResult>(this System.Threading.Tasks.Task<TResult> task, System.Func<System.Threading.Tasks.Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions continuationOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Runtime.CompilerServices.TaskAwaiter GetAwaiter(this System.Threading.Tasks.Task task);

    public static System.Runtime.CompilerServices.TaskAwaiter<TResult> GetAwaiter<TResult>(this System.Threading.Tasks.Task<TResult> task);
}
namespace System.Runtime.CompilerServices
{
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
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

    [System.AttributeUsage(System.AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerFilePathAttribute : System.Attribute
    {
        [System.Runtime.TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CallerFilePathAttribute();
    }

    [System.AttributeUsage(System.AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerLineNumberAttribute : System.Attribute
    {
        [System.Runtime.TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CallerLineNumberAttribute();
    }

    [System.AttributeUsage(System.AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerMemberNameAttribute : System.Attribute
    {
        [System.Runtime.TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CallerMemberNameAttribute();
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

    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class IteratorStateMachineAttribute : StateMachineAttribute
    {
        public IteratorStateMachineAttribute(System.Type stateMachineType);
    }

    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
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

    public struct YieldAwaitable
    {
        public YieldAwaitable.YieldAwaiter GetAwaiter();

        public struct YieldAwaiter
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

        public static void Write<T>(ref T location, T value) where T : class;
    }
}
namespace System.Threading.Tasks
{
    public static class TaskEx
    {
        public static Task Delay(int dueTime);

        public static Task Delay(System.TimeSpan dueTime);

        public static Task Delay(System.TimeSpan dueTime, System.Threading.CancellationToken cancellationToken);

        public static Task Delay(int dueTime, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> FromResult<TResult>(TResult result);

        public static Task Run(System.Action action);

        public static Task Run(System.Action action, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> Run<TResult>(System.Func<TResult> function);

        public static Task<TResult> Run<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public static Task Run(System.Func<Task> function);

        public static Task Run(System.Func<Task> function, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> Run<TResult>(System.Func<Task<TResult>> function);

        public static Task<TResult> Run<TResult>(System.Func<Task<TResult>> function, System.Threading.CancellationToken cancellationToken);

        public static Task WhenAll(params Task[] tasks);

        public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);

        public static Task WhenAll(System.Collections.Generic.IEnumerable<Task> tasks);

        public static Task<TResult[]> WhenAll<TResult>(System.Collections.Generic.IEnumerable<Task<TResult>> tasks);

        public static Task<Task> WhenAny(params Task[] tasks);

        public static Task<Task> WhenAny(System.Collections.Generic.IEnumerable<Task> tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(System.Collections.Generic.IEnumerable<Task<TResult>> tasks);

        public static System.Runtime.CompilerServices.YieldAwaitable Yield();
    }
}
