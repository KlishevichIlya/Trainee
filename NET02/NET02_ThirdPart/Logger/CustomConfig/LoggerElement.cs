using System.Configuration;

namespace Logger.CustomConfig
{
    public class LoggerElement : ConfigurationElement
    {
        [ConfigurationProperty("minlevel", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string MinLevel
        {
            get => ((string)(base["minlevel"]));
            set => base["minlevel"] = value;
        }
    }
}
