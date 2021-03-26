using System.Configuration;

namespace NET02_ThirdPart.CustomConfig
{
    public class StartupTargetsConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Targets")]
        public TargetsCollection TargetsItems => ((TargetsCollection)(base["Targets"]));
    }
}
