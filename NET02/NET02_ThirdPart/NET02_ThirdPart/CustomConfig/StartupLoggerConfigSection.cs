using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    public class StartupLoggerConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("loggers")]
        public LoggerCollection LoggerItems => ((LoggerCollection)(base["loggers"]));
    }
}
