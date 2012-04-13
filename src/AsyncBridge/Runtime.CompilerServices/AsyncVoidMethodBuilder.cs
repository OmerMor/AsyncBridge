namespace System.Runtime.CompilerServices
{
    public struct AsyncVoidMethodBuilder
    {
        public static AsyncVoidMethodBuilder Create()
        {
            return new AsyncVoidMethodBuilder();
        }

        public void SetException(Exception exception)
        {
            throw exception;
        }

        public void SetResult()
        {
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            // Should not get called as we don't implement the optimization that this method is used for.
            throw new NotImplementedException();
        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
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
    }
}