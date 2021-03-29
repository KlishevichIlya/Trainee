using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    public class TargetElement : ConfigurationElement
    {
        [ConfigurationProperty("type", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Type
        {
            get => ((string)(base["type"]));
            set => base["type"] = value;
        }
    }
}
