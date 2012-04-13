namespace System.Threading.Tasks
{
    internal class DelayTask
    {
        private readonly Timer m_timer;
        private readonly TaskCompletionSource<VoidTaskResult> m_taskCompletionSource = new TaskCompletionSource<VoidTaskResult>();
        private readonly CancellationToken m_cancellationToken;

        public DelayTask(CancellationToken cancellationToken, int millisecondsDelay)
        {
            if (cancellationToken.CanBeCanceled)
            {
                cancellationToken.Register(complete, false);
            }

            if (millisecondsDelay != Timeout.Infinite)
            {
                m_timer = new Timer(_ => complete(), null, millisecondsDelay, Timeout.Infinite);
            }
            m_cancellationToken = cancellationToken;
        }

        public Task Task
        {
            get { return m_taskCompletionSource.Task; }
        }

        private void complete()
        {
            var notDisposed =
                m_cancellationToken.IsCancellationRequested
                    ? m_taskCompletionSource.TrySetCanceled()
                    : m_taskCompletionSource.TrySetResult(default(VoidTaskResult));
            
            if (notDisposed && m_timer != null)
            {
                m_timer.Dispose();
            }
        }
    }
}