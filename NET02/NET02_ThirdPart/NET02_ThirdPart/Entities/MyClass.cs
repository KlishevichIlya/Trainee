using Logger.Attributes;


namespace NET02_ThirdPart.Entities
{
    [TrackingEntity]
    public class MyClass
    {
        [TrackingProperty(Name = "Custom Name")]
        public string PropertyString { get; set; }

        [TrackingProperty] public int PropertyInt { get; set; }

        [TrackingProperty] public int Sum = 100;

        public MyClass(string propertyString, int propertyInt)
        {
            PropertyString = propertyString;
            PropertyInt = propertyInt;
        }
    }
}
