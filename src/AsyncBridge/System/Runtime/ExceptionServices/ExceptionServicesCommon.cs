using System.Reflection;

namespace System.Runtime.ExceptionServices
{
    public sealed class ExceptionDispatchInfo
    {
        private static readonly Action<Exception> InternalPreserveStackTrace = (Action<Exception>)
            typeof(Exception)
            .GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.CreateDelegate(typeof(Action<Exception>));

        private ExceptionDispatchInfo(Exception exception)
        {
            SourceException = exception;
        }

        public static ExceptionDispatchInfo Capture(Exception source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), SR.ArgumentNull_Obj);
            }

            return new ExceptionDispatchInfo(source);
        }

        public Exception SourceException { get; }

        public void Throw()
        {
            InternalPreserveStackTrace?.Invoke(SourceException);
            throw SourceException;
        }

        public static void Throw(Exception source) => Capture(source).Throw();
    }
}
