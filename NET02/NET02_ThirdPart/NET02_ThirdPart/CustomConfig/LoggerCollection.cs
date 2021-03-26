using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    [ConfigurationCollection(typeof(LoggerElement))]
    public class LoggerCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new LoggerElement();

        protected override object GetElementKey(ConfigurationElement element) => ((LoggerElement)(element)).MinLevel;

        public LoggerElement this[int idx] => (LoggerElement)BaseGet(idx);
    }
}
