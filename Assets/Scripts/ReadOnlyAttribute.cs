using System;
using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// Read only in inspector
    /// </summary>
   [AttributeUsage(AttributeTargets.All)]
    public sealed class ReadOnlyAttribute : PropertyAttribute
    {
        public ReadOnlyAttribute()
            : base()
        {
            // Empty
        }
    }
}
