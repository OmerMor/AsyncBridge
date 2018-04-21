// Name:       AsyncBridge
// Public key: ACQAAASAAACUAAAABgIAAAAkAABSU0ExAAQAAAEAAQCLFl3K4YXiNrRI+T6dQfJ73C164NxT1pBidQ9sJZMSKVrEBhi53LnGTBdJZj0s83kCjfQ8tdBvxM4IDe7zH3TxhJDdo40tiZ4ZFOwnDv00373pftuR6JDZ3J3AIeWuhsFhxaofTb5UDfwsMW6M8ypuaTJpFG6v9EaSKJ9hajJPoA==

public static class AsyncCompatLibExtensions
{
    public static System.Runtime.CompilerServices.ConfiguredTaskAwaitable<TResult> ConfigureAwait<TResult>(this System.Threading.Tasks.Task<TResult> task, bool continueOnCapturedContext);

    public static System.Runtime.CompilerServices.ConfiguredTaskAwaitable ConfigureAwait(this System.Threading.Tasks.Task task, bool continueOnCapturedContext);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> action, object state);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> action, object state, System.Threading.CancellationToken token);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> action, object state, System.Threading.Tasks.TaskContinuationOptions taskOptions);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> action, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task ContinueWith(this System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task, object> action, object state, System.Threading.CancellationToken token, System.Threading.Tasks.TaskContinuationOptions taskOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task ContinueWith<TInResult>(this System.Threading.Tasks.Task<TInResult> task, System.Action<System.Threading.Tasks.Task<TInResult>, object> action, object state);

    public static System.Threading.Tasks.Task ContinueWith<TInResult>(this System.Threading.Tasks.Task<TInResult> task, System.Action<System.Threading.Tasks.Task<TInResult>, object> action, object state, System.Threading.CancellationToken token);

    public static System.Threading.Tasks.Task ContinueWith<TInResult>(this System.Threading.Tasks.Task<TInResult> task, System.Action<System.Threading.Tasks.Task<TInResult>, object> action, object state, System.Threading.Tasks.TaskContinuationOptions taskOptions);

    public static System.Threading.Tasks.Task ContinueWith<TInResult>(this System.Threading.Tasks.Task<TInResult> task, System.Action<System.Threading.Tasks.Task<TInResult>, object> action, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task ContinueWith<TInResult>(this System.Threading.Tasks.Task<TInResult> task, System.Action<System.Threading.Tasks.Task<TInResult>, object> action, object state, System.Threading.CancellationToken token, System.Threading.Tasks.TaskContinuationOptions taskOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> action, object state);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> action, object state, System.Threading.CancellationToken token);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> action, object state, System.Threading.Tasks.TaskContinuationOptions taskOptions);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> action, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TResult>(this System.Threading.Tasks.Task task, System.Func<System.Threading.Tasks.Task, object, TResult> action, object state, System.Threading.CancellationToken token, System.Threading.Tasks.TaskContinuationOptions taskOptions, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TInResult, TResult>(this System.Threading.Tasks.Task<TInResult> task, System.Func<System.Threading.Tasks.Task<TInResult>, object, TResult> action, object state);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TInResult, TResult>(this System.Threading.Tasks.Task<TInResult> task, System.Func<System.Threading.Tasks.Task<TInResult>, object, TResult> action, object state, System.Threading.CancellationToken token);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TInResult, TResult>(this System.Threading.Tasks.Task<TInResult> task, System.Func<System.Threading.Tasks.Task<TInResult>, object, TResult> action, object state, System.Threading.Tasks.TaskContinuationOptions taskOptions);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TInResult, TResult>(this System.Threading.Tasks.Task<TInResult> task, System.Func<System.Threading.Tasks.Task<TInResult>, object, TResult> action, object state, System.Threading.Tasks.TaskScheduler scheduler);

    public static System.Threading.Tasks.Task<TResult> ContinueWith<TInResult, TResult>(this System.Threading.Tasks.Task<TInResult> task, System.Func<System.Threading.Tasks.Task<TInResult>, object, TResult> action, object state, System.Threading.CancellationToken token, System.Threading.Tasks.TaskContinuationOptions taskOptions, System.Threading.Tasks.TaskScheduler scheduler);

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

    public struct ConfiguredTaskAwaitable
    {
        public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter();

        public struct ConfiguredTaskAwaiter
        {
            public bool IsCompleted { get; }

            public void GetResult();

            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }

    public struct ConfiguredTaskAwaitable<TResult>
    {
        public ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter GetAwaiter();

        public struct ConfiguredTaskAwaiter
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

    public struct TaskAwaiter
    {
        public bool IsCompleted { get; }

        public void GetResult();

        public void OnCompleted(System.Action continuation);

        [System.Security.SecurityCritical]
        public void UnsafeOnCompleted(System.Action continuation);
    }

    public struct TaskAwaiter<TResult>
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
