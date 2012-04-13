using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var completionSource = new TaskCompletionSource<TResult>(result);
            completionSource.TrySetResult(result);
            return completionSource.Task;
        }

        public static YieldAwaitable Yield()
        {
            return new YieldAwaitable((object)SynchronizationContext.Current ?? TaskScheduler.Current);
        }

        public static ConfigurableTaskAwaitable<T> ConfigureAwait<T>(this Task<T> original, bool continueOnCapturedContext)
        {
            return new ConfigurableTaskAwaitable<T>(original, continueOnCapturedContext);
        }

        public static ConfigurableTaskAwaitable ConfigureAwait(this Task original, bool continueOnCapturedContext)
        {
            return new ConfigurableTaskAwaitable(original, continueOnCapturedContext);
        }

        // Methods which are implemented in terms of TaskFactory
        public static Task<T[]> WhenAll<T>(params Task<T>[] tasks)
        {
            return new TaskFactory<T[]>().ContinueWhenAll(
                tasks,
                finishedTasks => finishedTasks
                                     .Select(t => t.Result)
                                     .ToArray(),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public static Task<T> WhenAny<T>(params Task<T>[] tasks)
        {
            return new TaskFactory<T>().ContinueWhenAny(tasks, task => task.Result,
                                                        TaskContinuationOptions.ExecuteSynchronously);
        }

        // Everything else is implemented in terms of those
        public static async Task<IEnumerable<T>> WhenAll<T>(IEnumerable<Task<T>> tasks)
        {
            return await WhenAll(tasks.ToArray());
        }

        public static async Task WhenAll(IEnumerable<Task> tasks)
        {
            await WhenAll(tasks.Select(genericify));
        }

        public static async Task WhenAll(params Task[] tasks)
        {
            await WhenAll(tasks.Select(genericify));
        }

        public static async Task<T> WhenAny<T>(IEnumerable<Task<T>> tasks)
        {
            return await WhenAny(tasks.ToArray());
        }

        public static async Task WhenAny(IEnumerable<Task> tasks)
        {
            await WhenAny(tasks.Select(genericify));
        }

        public static async Task WhenAny(params Task[] tasks)
        {
            await WhenAny(tasks.Select(genericify));
        }

        // Helpers
        private static async Task<VoidTaskResult> genericify(Task task)
        {
            await task;
            return default(VoidTaskResult);
        }

        private static readonly Lazy<Task> s_cancelledTask = new Lazy<Task>(() =>
        {
            var tcs = new TaskCompletionSource<VoidTaskResult>();
            tcs.SetCanceled();
            return tcs.Task;
        }, isThreadSafe: true);

        private static readonly Lazy<Task> s_completedTask = new Lazy<Task>(() =>
        {
            var tcs = new TaskCompletionSource<VoidTaskResult>();
            tcs.SetResult(default(VoidTaskResult));
            return tcs.Task;
        }, isThreadSafe: true);
    }
}