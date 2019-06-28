using System;
using UnityEngine;

namespace Source.Runtime.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ReadOnlyAttribute : PropertyAttribute
    {

    }
}