using NET02_ThirdPart.Attributes;

namespace NET02_ThirdPart.Entities
{
    [TrackingEntity]
    public class MyClass
    {
        [TrackingProperty(Name = "Custom Name")]
        public string FieldString { get; set; }
        [TrackingProperty]
        public int FieldInt { get; set; }

        public MyClass(string fieldString, int fieldInt)
        {
            FieldString = fieldString;
            FieldInt = fieldInt;
        }
    }
}
