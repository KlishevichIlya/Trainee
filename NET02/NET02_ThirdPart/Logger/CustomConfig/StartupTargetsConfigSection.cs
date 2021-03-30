using System.Configuration;

namespace Logger.CustomConfig
{
    public class StartupTargetsConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Targets")]
        public TargetsCollection TargetsItems => ((TargetsCollection)(base["Targets"]));
    }
}
