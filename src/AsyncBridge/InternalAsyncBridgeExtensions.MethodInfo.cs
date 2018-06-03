using System;
using System.Reflection;

internal static partial class InternalAsyncBridgeExtensions
{
    public static Delegate CreateDelegate(this MethodInfo method, Type delegateType)
    {
        return Delegate.CreateDelegate(delegateType, method);
    }
}
