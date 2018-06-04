// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/Runtime/CompilerServices/IteratorStateMachineAttribute.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT
// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System.Runtime.CompilerServices/IteratorStateMachineAttribute.xml
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

namespace System.Runtime.CompilerServices
{
    /// <summary>Indicates whether a method in Visual Basic is marked with the <see langword="Iterator" /> modifier.</summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class IteratorStateMachineAttribute : StateMachineAttribute
    {
        /// <param name="stateMachineType">The type object for the underlying state machine type that's used to implement a state machine method.</param>
        /// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.IteratorStateMachineAttribute" /> class.</summary><remarks>To be added.</remarks>
        public IteratorStateMachineAttribute(Type stateMachineType)
            : base(stateMachineType)
        {
        }
    }
}
