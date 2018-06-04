// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/Threading/LockRecursionException.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT
// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System.Threading/LockRecursionException.xml
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

#if NET20
using System;
using System.Runtime.Serialization;

namespace System.Threading
{
    /// <summary>The exception that is thrown when recursive entry into a lock is not compatible with the recursion policy for the lock.</summary>
    [Serializable]
    public class LockRecursionException : System.Exception
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class.</summary>
        public LockRecursionException()
        {
        }

        /// <param name="message">The message that describes the exception. The caller of this constructor must make sure that this string has been localized for the current system culture.</param>
        /// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with a specified message that describes the error.</summary>
        public LockRecursionException(string message)
            : base(message)
        {
        }

        /// <param name="message">The message that describes the exception. The caller of this constructor must make sure that this string has been localized for the current system culture.</param>
        /// <param name="innerException">The exception that caused the current exception. If the <c>innerException</c> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        /// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        public LockRecursionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with serialized data.</summary>
        protected LockRecursionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
#endif
