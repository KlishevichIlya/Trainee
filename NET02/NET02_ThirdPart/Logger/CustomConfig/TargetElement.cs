using System.Configuration;

namespace Logger.CustomConfig
{
    public class TargetElement : ConfigurationElementCollection
    {
        [ConfigurationProperty("type", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Type
        {
            get => ((string)(base["type"]));
            set => base["type"] = value;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TargetParams();
        }

        protected override object GetElementKey(ConfigurationElement element) => ((TargetParams)(element)).Name;

        public TargetParams this[int idx] => (TargetParams)BaseGet(idx);
    }
}
