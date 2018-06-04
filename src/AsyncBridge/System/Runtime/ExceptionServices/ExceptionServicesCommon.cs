// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System.Runtime.ExceptionServices/ExceptionDispatchInfo.xml
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

using System.Reflection;

namespace System.Runtime.ExceptionServices
{
    /// <summary>Represents an exception whose state is captured at a certain point in code.</summary>
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
        
        /// <param name="source">The exception whose state is captured, and which is represented by the returned object.</param>
        /// <summary>Creates an <see cref="T:System.Runtime.ExceptionServices.ExceptionDispatchInfo" /> object that represents the specified exception at the current point in code.</summary>
        /// <returns>An object that represents the specified exception at the current point in code.</returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static ExceptionDispatchInfo Capture(Exception source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), SR.ArgumentNull_Obj);
            }

            return new ExceptionDispatchInfo(source);
        }
        
        /// <summary>Gets the exception that is represented by the current instance.</summary>
        /// <value>The exception that is represented by the current instance.</value>
        public Exception SourceException { get; }
        
        /// <summary>Throws the exception that is represented by the current<see cref= "T:System.Runtime.ExceptionServices.ExceptionDispatchInfo" /> object, after restoring the state that was saved when the exception was captured.</summary>
        public void Throw()
        {
            InternalPreserveStackTrace?.Invoke(SourceException);
            throw SourceException;
        }

#pragma warning disable CS1591 // Per .NET Core 2.1
        public static void Throw(Exception source) => Capture(source).Throw();
#pragma warning restore CS1591
    }
}
