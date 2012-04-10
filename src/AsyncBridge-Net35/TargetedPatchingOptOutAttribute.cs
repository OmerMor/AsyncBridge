using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Runtime
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public sealed class TargetedPatchingOptOutAttribute : Attribute
    {
        private String m_reason;

        public TargetedPatchingOptOutAttribute(String reason)
        {
            m_reason = reason;
        }

        public String Reason
        {
            get { return m_reason; }
        }

        private TargetedPatchingOptOutAttribute() { }
    }
}
