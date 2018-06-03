// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/SerializableAttribute.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT

#if PORTABLE
namespace System
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
    internal sealed class SerializableAttribute : Attribute
    {
        public SerializableAttribute() { }
    }
}
#endif
