using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    public class TargetParams : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get => ((string)(base["name"]));
            set => base["name"] = value;
        }

        [ConfigurationProperty("value", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Value
        {
            get => ((string)(base["value"]));
            set => base["value"] = value;
        }
    }
}
