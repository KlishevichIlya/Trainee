using System.Configuration;

namespace Logger.CustomConfig
{
    public class StartupLoggerConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("loggers")]
        public LoggerCollection LoggerItems => ((LoggerCollection)(base["loggers"]));
    }
}
