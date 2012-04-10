using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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
            var num = (long)delay.TotalMilliseconds;
            if (num < -1L || num > int.MaxValue)
                throw new ArgumentOutOfRangeException("delay");

            return Delay((int)num, cancellationToken);
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
                return s_cancelledTask.Value;

            if (millisecondsDelay == 0)
                return s_completedTask.Value;

            var delayTask = new DelayTask(cancellationToken, millisecondsDelay);

            return delayTask.Task;
        }

        public static async Task<IEnumerable<T>> WhenAll<T>(IEnumerable<Task<T>> tasks)
        {
            // Just wait for all the things in turn
            List<T> finishedItems = new List<T>();
            foreach (Task<T> eachTask in tasks)
            {
                finishedItems.Add(await eachTask);
            }

            return finishedItems;
        }

        public static async Task WhenAll(IEnumerable<Task> tasks)
        {
            await WhenAll(tasks.Select(Genericify));
        }

        public static Task<T> WhenAny<T>(Task<T>[] tasks)
        {
            return new TaskFactory<T>().ContinueWhenAny(tasks, task => task.Result);
        }

        private static async Task<object> Genericify(Task task)
        {
            await task;
            return null;
        }

        private static readonly Lazy<Task> s_cancelledTask = new Lazy<Task>(() =>
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetCanceled();
            return tcs.Task;
        }, isThreadSafe: true);

        private static readonly Lazy<Task> s_completedTask = new Lazy<Task>(() =>
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }, isThreadSafe: true);
    }
}