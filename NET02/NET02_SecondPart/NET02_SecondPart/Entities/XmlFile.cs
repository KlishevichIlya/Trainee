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
    }
}
