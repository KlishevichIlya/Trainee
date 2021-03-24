using NET02_SecondPart.Entities;
using System;

namespace NET02_SecondPart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = XmlFile.Read("settings.xml");

            Console.WriteLine(config);

            foreach (var l in config.GetIncorrectLogins())
            {
                Console.WriteLine(l);
            }

            Console.WriteLine(config.IsCorrectConfiguration());
            config.Fix();

            WriteJson.ConvertToJson(config);
            Console.ReadLine();
        }
    }
}
