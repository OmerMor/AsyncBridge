namespace System.Runtime
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public sealed class TargetedPatchingOptOutAttribute : Attribute
    {
        private readonly string m_reason;

        public TargetedPatchingOptOutAttribute(String reason)
        {
            m_reason = reason;
        }

        public String Reason
        {
            get { return m_reason; }
        }
    }
}
