using System;

namespace Logger.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
