using NET02_SecondPart.Entities;
using System;
using System.IO;

namespace NET02_SecondPart
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var printerInformation = new ConsoleInformationPrinter();
            var incorrectLoginsGetter = new IncorrectLoginsGetter();
            var incorrectLoginPrinter = new ConsoleIncorrectLoginsPrinter();
            var configurationChecker = new ConfigurationChecker();

            var conf = XmlFile.Read("settings.xml");

            conf.PrintInformation(printerInformation);
            conf.PrintIncorrectLogins(incorrectLoginPrinter, conf.GetIncorrectLogins(incorrectLoginsGetter));

            Console.WriteLine(conf.IsCorrectConfiguration(configurationChecker));


            var temp = Directory.GetCurrentDirectory();

            //conf.PrintInformation(printerInformation);

            //conf.PrintIncorrectLogins(conf.GetIncorrectLogins(incorrectLoginsGetter));

            WriteJson.ConvertToJson(conf);

            Console.ReadLine();
        }
    }
}
