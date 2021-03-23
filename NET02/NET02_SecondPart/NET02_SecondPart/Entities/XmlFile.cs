using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NET02_SecondPart.Entities
{
    public static class XmlFile
    {
        private const string CurrentDirectory = @"D:\BasicTraining\NET02\NET02_SecondPart\Config\";

        public static Configuration Read(string filename)
        {
            var config = new Configuration();
            var xml = XDocument.Load(CurrentDirectory + filename);
            foreach (var item in xml.Elements("config"))
            {
                foreach (var lg in item.Elements("login"))
                {
                    var login = new Login { Name = lg.Attribute("name")?.Value };
                    foreach (var wn in lg.Elements("window"))
                    {
                        var temp = new Window
                        {
                            Top = wn.Element("top")?.Value,
                            Width = wn.Element("width")?.Value,
                            Height = wn.Element("height")?.Value,
                            Left = wn.Element("left")?.Value,
                            Title = wn.Attribute("title")?.Value
                        };
                        login.Windows.Add(temp);
                    }

                    config.Logins.Add(login);
                }
            }

            return config;
        }

        public static void PrintInformation(Configuration config)
        {
            foreach (var login in config.Logins)
            {
                Console.WriteLine($"Login : {login.Name}");
                foreach (var wn in login.Windows)
                {
                    Console.Write("\t" + wn.Title + "(");
                    Console.Write(wn.Top == null ? "?" + "," : wn.Top + ",");
                    Console.Write(wn.Left == null ? "?" + "," : wn.Left + ",");
                    Console.Write(wn.Width == null ? "?" + "," : wn.Width + ",");
                    Console.WriteLine(wn.Height == null ? "?" + ")" : wn.Height + ")");
                }
            }
        }

        public static void PrintIncorrectLogin(List<string> incorrectLogins)
        {
            Console.Write("Incorrect logins: ");
            foreach (var login in incorrectLogins)
            {
                Console.Write(login + "");
            }

            Console.WriteLine();
        }

        public static List<string> CheckConfiguration(Configuration config)
        {
            var incorrectLogins = (config.Logins.SelectMany(login => login.Windows, (login, wn) => new { login, wn })
                .Where(@t => @t.wn.Title == "main")
                .Where(@t => @t.wn.Top == null || @t.wn.Left == null || @t.wn.Height == null || @t.wn.Width == null)
                .Select(@t => @t.login.Name)).ToList();

            Console.WriteLine(incorrectLogins.Any()
                ? "Configuration for login is incorrect."
                : "Configuration for login is correct.");

            return incorrectLogins;
        }
    }
}
