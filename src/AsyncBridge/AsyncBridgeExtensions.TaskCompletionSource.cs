// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System.Threading.Tasks/TaskCompletionSource%601.xml
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

#if NET40 || PORTABLE
using System;
using System.Threading;
using System.Threading.Tasks;

public static partial class AsyncBridgeExtensions
{
    /// <param name="taskCompletionSource">The current instance.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <summary>Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" /> state and enables a cancellation token to be stored in the canceled task.</summary>
    /// <returns><see langword="true" /> if the operation is successful; otherwise, <see langword="false" />.</returns>
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
