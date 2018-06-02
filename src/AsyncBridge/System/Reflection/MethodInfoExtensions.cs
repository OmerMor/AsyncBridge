namespace System.Reflection
{
    internal static class MethodInfoExtensions
    {
        public static Delegate CreateDelegate(this MethodInfo method, Type delegateType)
        {
            return Delegate.CreateDelegate(delegateType, method);
        }
    }
}
