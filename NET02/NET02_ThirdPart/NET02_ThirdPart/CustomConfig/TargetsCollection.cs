using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    [ConfigurationCollection(typeof(TargetElement))]
    public class TargetsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new TargetElement();

        protected override object GetElementKey(ConfigurationElement element) => ((TargetElement)(element)).Type;

        public TargetElement this[int idx] => (TargetElement)BaseGet(idx);
    }
}
