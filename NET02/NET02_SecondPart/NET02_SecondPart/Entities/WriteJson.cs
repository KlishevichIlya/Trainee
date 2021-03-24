using Newtonsoft.Json;
using System.IO;

namespace NET02_SecondPart.Entities
{
    public static class WriteJson
    {
        public static void ConvertToJson(Configuration config)
        {
            foreach (var login in config.Logins)
            {
                var fileName = Directory.GetCurrentDirectory() + @"\Config\" + login.Name +
                               ".json";
                var output = JsonConvert.SerializeObject(login, Formatting.Indented);
                File.WriteAllText(fileName, output);
            }
        }
    }
}
