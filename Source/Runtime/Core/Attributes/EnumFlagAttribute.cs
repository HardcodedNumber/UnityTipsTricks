using System;
using UnityEngine;

namespace Source.Runtime.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumFlagAttribute : PropertyAttribute
    {
        public EnumFlagAttribute()
        {
        }
    }
}