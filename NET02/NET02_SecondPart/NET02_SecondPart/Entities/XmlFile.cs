using System;
using System.IO;
using System.Xml.Linq;

namespace NET02_SecondPart.Entities
{
    public static class XmlFile
    {
        public static Configuration Read(string filename)
        {
            var config = new Configuration();
            var xml = XDocument.Load(Directory.GetCurrentDirectory() + @"\Config\" + filename);
            foreach (var item in xml.Elements("config"))
            {
                foreach (var lg in item.Elements("login"))
                {
                    var login = new Login { Name = lg.Attribute("name")?.Value };
                    foreach (var wn in lg.Elements("window"))
                    {
                        var temp = new Window
                        {
                            Top = Convert.ToInt32(wn.Element("top")?.Value),
                            Width = Convert.ToInt32(wn.Element("width")?.Value),
                            Height = Convert.ToInt32(wn.Element("height")?.Value),
                            Left = Convert.ToInt32(wn.Element("left")?.Value),
                            Title = wn.Attribute("title")?.Value
                        };
                        login.Windows.Add(temp);
                    }

                    config.Logins.Add(login);
                }
            }

            return config;
        }
    }
}
