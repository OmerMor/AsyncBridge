using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBridge
{
    public static class TaskUtils
    {
        public static Task Delay(TimeSpan delay)
        {
            return Delay(delay, CancellationToken.None);
        }

        public static Task Delay(TimeSpan delay, CancellationToken cancellationToken)
        {
            var num = (long) delay.TotalMilliseconds;
            if (num < -1L || num > int.MaxValue)
                throw new ArgumentOutOfRangeException("delay");

            return Delay((int) num, cancellationToken);
        }

        public static Task Delay(int millisecondsDelay)
        {
            return Delay(millisecondsDelay, CancellationToken.None);
        }

        public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
        {
            if (millisecondsDelay < Timeout.Infinite)
                throw new ArgumentOutOfRangeException("millisecondsDelay");

            if (cancellationToken.IsCancellationRequested)
                return fromCancellation(cancellationToken);

            if (millisecondsDelay == 0)
                return s_completedTask.Value;

            var delayPromise = new DelayPromise(cancellationToken);
            if (cancellationToken.CanBeCanceled)
                delayPromise.Registration = cancellationToken.Register(state => ((DelayPromise) state).Complete(),
                                                                         delayPromise, useSynchronizationContext: false);
            if (millisecondsDelay != Timeout.Infinite)
            {
                delayPromise.Timer = new Timer(state => ((DelayPromise) state).Complete(), delayPromise,
                                                 millisecondsDelay, Timeout.Infinite);
                GC.SuppressFinalize(delayPromise.Timer);
            }
            return delayPromise.TaskCompletionSource.Task;
        }

        private sealed class DelayPromise
        {
            internal CancellationTokenRegistration Registration;
            internal Timer Timer;
            internal readonly TaskCompletionSource<object> TaskCompletionSource = new TaskCompletionSource<object>();
            private readonly CancellationToken m_token;

            internal DelayPromise(CancellationToken token)
                //: base((object)null, CancellationToken.None, TaskCreationOptions.None, InternalTaskOptions.PromiseTask)
            {
                m_token = token;
            }

            internal void Complete()
            {
                var alreadyDisposed =
                    !(m_token.IsCancellationRequested ? TaskCompletionSource.TrySetCanceled() : TaskCompletionSource.TrySetResult(null));
                if (alreadyDisposed)
                    return;
                if (Timer != null)
                    Timer.Dispose();
                Registration.Dispose();
            }
        }

        private static Task fromCancellation(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
                throw new ArgumentOutOfRangeException("cancellationToken");
            var tcs = new TaskCompletionSource<object>();
            tcs.SetCanceled();
            return tcs.Task;
        }

        private static readonly Lazy<Task> s_completedTask = new Lazy<Task>(() =>
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }, isThreadSafe: true);
    }
}