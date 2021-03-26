using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    public class TargetElement : ConfigurationElement
    {
        [ConfigurationProperty("namespace", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Namespace
        {
            get => ((string)(base["namespace"]));
            set => base["namespace"] = value;
        }

        [ConfigurationProperty("assembly", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Assembly
        {
            get => ((string)(base["assembly"]));
            set => base["assembly"] = value;
        }

        [ConfigurationProperty("class", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Class
        {
            get => ((string)(base["class"]));
            set => base["class"] = value;
        }
    }
}
