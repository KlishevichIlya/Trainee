using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace NET02_SecondPart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var xml = XDocument.Load(@"D:\BasicTraining\NET02\NET02_SecondPart\Config\settings.xml");
            var config = xml.Element("config");

            if (config != null)
            {
                foreach (var item in config.Elements("login"))
                {
                    Console.WriteLine($"Login : {item.Attribute("name")?.Value}");
                    foreach (var window in item.Elements("window"))
                    {
                        Console.Write("\t" + window.Attribute("title")?.Value + "(");
                        Console.Write(window.Element("top") == null ? "?" + "," : window.Element("top").Value + ",");
                        Console.Write(window.Element("left") == null ? "?" + "," : window.Element("left").Value + ",");
                        Console.Write(window.Element("width") == null
                            ? "?" + ","
                            : window.Element("width").Value + ",");
                        Console.WriteLine(window.Element("height") == null
                            ? "?" + ")"
                            : window.Element("height").Value + ")");
                    }
                }
                Console.WriteLine();

                var log = CheckCorrectLogin(config);

                Console.Write("Incorrect logins : ");
                foreach (var item in log)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            WorkWithJson(xml);
            Console.ReadLine();
        }

        public static IEnumerable CheckCorrectLogin(XElement config)
        {
            var incorrectLogins = (from login in config.Elements("login")
                                   where login.Elements("window")
                                       .Where(wn => wn.Attribute("title")?.Value == "main")
                                       .Any(wn => wn.Element("top") == null || wn.Element("left") == null || wn.Element("width") == null ||
                                                  wn.Element("height") == null)
                                   select login.Attribute("name")?.Value).ToList();
            if (incorrectLogins.Any())
                Console.WriteLine("Configuration for login is incorrect.");
            return incorrectLogins;
        }

        public static void WorkWithJson(XDocument xml)
        {
            var json = JsonConvert.SerializeObject(xml, Formatting.Indented);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            for (var i = 0; i < xml.Element("config")?.Elements("login").Count(); i++)
            {
                string fileName = @"D:\BasicTraining\NET02\NET02_SecondPart\Config\" +
                                  jsonObj?["config"]["login"][i]["@name"] + ".json";

                for (var j = 0; j < xml.Element("config")?.Element("login")?.Elements("window").Count(); j++)
                {
                    if (jsonObj["config"]["login"][i]["window"][j]["top"] == null)
                        jsonObj["config"]["login"][i]["window"][j]["top"] = "0";
                    if (jsonObj["config"]["login"][i]["window"][j]["left"] == null)
                        jsonObj["config"]["login"][i]["window"][j]["left"] = "0";
                    if (jsonObj["config"]["login"][i]["window"][j]["width"] == null)
                        jsonObj["config"]["login"][i]["window"][j]["width"] = "400";
                    if (jsonObj["config"]["login"][i]["window"][j]["height"] == null)
                        jsonObj["config"]["login"][i]["window"][j]["height"] = "150";
                }

                string output = JsonConvert.SerializeObject(jsonObj?["config"]["login"][i], Formatting.Indented);
                File.WriteAllText(fileName, output);
            }

            Console.WriteLine();
        }
    }
}
