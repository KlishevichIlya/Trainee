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
                            Top = int.TryParse(wn.Element("top")?.Value, out var t) ? t : (int?)null,
                            Width = int.TryParse(wn.Element("width")?.Value, out t) ? t : (int?)null,
                            Height = int.TryParse(wn.Element("height")?.Value, out t) ? t : (int?)null,
                            Left = int.TryParse(wn.Element("left")?.Value, out t) ? t : (int?)null,
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
