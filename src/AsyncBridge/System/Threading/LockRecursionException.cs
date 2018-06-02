// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/Threading/LockRecursionException.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT

#if NET20
using System;
using System.Runtime.Serialization;

namespace System.Threading
{
    [Serializable]
    public class LockRecursionException : System.Exception
    {
        public LockRecursionException()
        {
        }

        public LockRecursionException(string message)
            : base(message)
        {
        }

        public LockRecursionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected LockRecursionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
#endif
