#if NET40 || PORTABLE
using System;
using System.Threading;
using System.Threading.Tasks;

public static partial class AsyncBridgeExtensions
{
    public static bool TrySetCanceled<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, CancellationToken cancellationToken)
    {
        if (PerTResult<TResult>.TrySetCanceledFunc != null)
        {
            return PerTResult<TResult>.TrySetCanceledFunc.Invoke(taskCompletionSource, cancellationToken);
        }

        return taskCompletionSource.TrySetCanceled();
    }

    private static class PerTResult<TResult>
    {
        public static readonly Action<TaskCompletionSource<TResult>, CancellationToken> SetCanceledAction = (Action<TaskCompletionSource<TResult>, CancellationToken>)
            typeof(TaskCompletionSource<TResult>)
                .GetMethod("SetCanceled", new[] { typeof(CancellationToken) })
                ?.CreateDelegate(typeof(Action<TaskCompletionSource<TResult>, CancellationToken>));

        public static readonly Func<TaskCompletionSource<TResult>, CancellationToken, bool> TrySetCanceledFunc = (Func<TaskCompletionSource<TResult>, CancellationToken, bool>)
            typeof(TaskCompletionSource<TResult>)
                .GetMethod("TrySetCanceled", new[] { typeof(CancellationToken) })
                ?.CreateDelegate(typeof(Func<TaskCompletionSource<TResult>, CancellationToken, bool>));
    }
}
#endif
