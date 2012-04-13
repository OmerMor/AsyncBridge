namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerLineNumberAttribute : Attribute
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CallerLineNumberAttribute()
        {
        }
    }
}