using System.Threading;
using System.Threading.Tasks;

namespace AsyncBridge
{
    class DelayTask
    {
        private readonly Timer m_timer;
        private readonly TaskCompletionSource<object> m_taskCompletionSource = new TaskCompletionSource<object>();
        private readonly CancellationToken m_cancellationToken;

        public DelayTask(CancellationToken cancellationToken, int millisecondsDelay)
        {
            if (cancellationToken.CanBeCanceled)
            {
                cancellationToken.Register(Complete, false);
            }

            if (millisecondsDelay != Timeout.Infinite)
            {
                m_timer = new Timer(_ => Complete(), null, millisecondsDelay, Timeout.Infinite);
            }
            m_cancellationToken = cancellationToken;
        }

        public Task Task
        {
            get { return m_taskCompletionSource.Task; }
        }

        private void Complete()
        {
            var alreadyDisposed =
                !(m_cancellationToken.IsCancellationRequested ? m_taskCompletionSource.TrySetCanceled() : m_taskCompletionSource.TrySetResult(null));
            if (alreadyDisposed)
                return;
            if (m_timer != null)
                m_timer.Dispose();
        }
    }
}