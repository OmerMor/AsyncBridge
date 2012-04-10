using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    public struct AsyncTaskMethodBuilder
    {
        TaskCompletionSource<object> m_tcs;

        public Task Task { get { return m_tcs.Task; } }

        public static AsyncTaskMethodBuilder Create()
        {
            AsyncTaskMethodBuilder builder;
            builder.m_tcs = new TaskCompletionSource<object>();
            return builder;
        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            // Should not get called as we don't implement the optimization that this method is used for.
            throw new NotImplementedException();
        }

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        public void SetResult()
        {
            m_tcs.SetResult(null);
        }

        public void SetException(Exception exception)
        {
            m_tcs.SetException(exception);
        }
    }

    public struct AsyncTaskMethodBuilder<T>
    {
        TaskCompletionSource<T> m_tcs;

        public Task<T> Task { get { return m_tcs.Task; } }

        public static AsyncTaskMethodBuilder<T> Create()
        {
            AsyncTaskMethodBuilder<T> builder;
            builder.m_tcs = new TaskCompletionSource<T>();
            return builder;
        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            // Should not get called as we don't implement the optimization that this method is used for.
            throw new NotImplementedException();
        }

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            AwaitOnCompleted(ref awaiter, ref stateMachine);
        }

        public void SetResult(T result)
        {
            m_tcs.SetResult(result);
        }

        public void SetException(Exception exception)
        {
            m_tcs.SetException(exception);
        }
    }

}