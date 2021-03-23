using Newtonsoft.Json;
using System.IO;

namespace NET02_SecondPart.Entities
{
    public static class WriteJson
    {
        private const string CurrentDirectory = @"D:\BasicTraining\NET02\NET02_SecondPart\Config\";

        public static void WorkWithJson(Configuration config)
        {
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            for (var i = 0; i < config.Logins.Count; i++)
            {
                string fileName = CurrentDirectory + jsonObj?["Logins"][i]["Name"] + ".json";
                foreach (var lg in config.Logins)
                {
                    for (var j = 0; j < lg.Windows.Count; j++)
                    {
                        if (jsonObj["Logins"][i]["Windows"][j]["Top"] == null)
                            jsonObj["Logins"][i]["Windows"][j]["Top"] = "0";
                        if (jsonObj["Logins"][i]["Windows"][j]["Left"] == null)
                            jsonObj["Logins"][i]["Windows"][j]["Left"] = "0";
                        if (jsonObj["Logins"][i]["Windows"][j]["Width"] == null)
                            jsonObj["Logins"][i]["Windows"][j]["Width"] = "400";
                        if (jsonObj["Logins"][i]["Windows"][j]["Height"] == null)
                            jsonObj["Logins"][i]["Windows"][j]["Height"] = "150";
                    }
                }

                string output = JsonConvert.SerializeObject(jsonObj?["Logins"][i], Formatting.Indented);
                File.WriteAllText(fileName, output);
            }
        }
    }
}
