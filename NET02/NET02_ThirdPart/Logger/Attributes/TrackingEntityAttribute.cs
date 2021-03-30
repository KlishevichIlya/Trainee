using System;

namespace Logger.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TrackingEntityAttribute : Attribute
    {
    }
}
