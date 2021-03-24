using Newtonsoft.Json;
using System.IO;

namespace NET02_SecondPart.Entities
{
    public static class WriteJson
    {
        public static void ConvertToJson(Configuration config)
        {
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            for (var i = 0; i < config.Logins.Count; i++)
            {
                string fileName = Directory.GetCurrentDirectory() + @"\Config\" + jsonObj?["Logins"][i]["Name"] +
                                  ".json";
                config.ChangeConfiguration(jsonObj, i);

                string output = JsonConvert.SerializeObject(jsonObj?["Logins"][i], Formatting.Indented);
                File.WriteAllText(fileName, output);
            }
        }
    }
}
