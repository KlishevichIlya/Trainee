using System;

namespace NET02_ThirdPart.Attributes
{
    public class TrackingPropertyAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
