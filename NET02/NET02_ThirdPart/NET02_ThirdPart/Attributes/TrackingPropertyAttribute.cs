using System;

namespace NET02_ThirdPart.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
