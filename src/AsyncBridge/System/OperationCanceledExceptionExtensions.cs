using System.Reflection;
using System.Threading;

namespace System
{
    internal static class OperationCanceledExceptionExtensions
    {
#if NET35
        public static CancellationToken GetCancellationToken(this OperationCanceledException exception)
        {
            return default;
        }

        public static OperationCanceledException CreateOperationCanceledException(CancellationToken cancellationToken)
        {
            return new OperationCanceledException(SR.OperationCanceled);
        }
#elif PORTABLE
        private static readonly Func<OperationCanceledException, CancellationToken> CancellationTokenGetter = (Func<OperationCanceledException, CancellationToken>)
            typeof(OperationCanceledException)
                .GetProperty("CancellationToken", BindingFlags.Public | BindingFlags.Instance)
                ?.GetGetMethod()
                ?.CreateDelegate(typeof(Func<OperationCanceledException, CancellationToken>));

        public static CancellationToken GetCancellationToken(this OperationCanceledException exception)
        {
            return CancellationTokenGetter == null ? default : CancellationTokenGetter.Invoke(exception);
        }

        private static readonly ConstructorInfo CancellationTokenConstructor = 
            typeof(OperationCanceledException)
                .GetConstructor(new[] { typeof(string), typeof(CancellationToken) });

        public static OperationCanceledException CreateOperationCanceledException(CancellationToken cancellationToken)
        {
            if (CancellationTokenConstructor != null)
            {
                return (OperationCanceledException)CancellationTokenConstructor?.Invoke(new object[] {SR.OperationCanceled, cancellationToken});
            }

            return new OperationCanceledException(SR.OperationCanceled);
        }
#else
        public static CancellationToken GetCancellationToken(this OperationCanceledException exception)
        {
            return exception.CancellationToken;
        }

        public static OperationCanceledException CreateOperationCanceledException(CancellationToken cancellationToken)
        {
            return new OperationCanceledException(SR.OperationCanceled, cancellationToken);
        }
#endif
    }
}
