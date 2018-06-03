// https://github.com/dotnet/corefx/blob/v2.1.0/src/System.Threading.Tasks.Parallel/src/System/Threading/Tasks/Box.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/corefx/blob/v2.1.0/LICENSE.TXT

#if NET20 || NET35
using System;

namespace System.Threading.Tasks
{
    /// <summary>Utility class for allocating value types as heap variables.</summary>
    internal class Box<T>
    {
        internal T Value;

        internal Box(T value)
        {
            this.Value = value;
        }
    }  // class Box<T>
}  // namespace
#endif
