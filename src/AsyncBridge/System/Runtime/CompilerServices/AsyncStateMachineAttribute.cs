// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/Runtime/CompilerServices/AsyncStateMachineAttribute.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT
// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System.Runtime.CompilerServices/AsyncStateMachineAttribute.xml
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

namespace System.Runtime.CompilerServices
{
    /// <summary>Indicates whether a method is marked with the <c>async</c> modifier.</summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class AsyncStateMachineAttribute : StateMachineAttribute
    {
        /// <param name="stateMachineType">The type object for the underlying state machine type that's used to implement a state machine method.</param>
        /// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.AsyncStateMachineAttribute" /> class.</summary>
        public AsyncStateMachineAttribute(Type stateMachineType)
            : base(stateMachineType)
        {
        }
    }
}
