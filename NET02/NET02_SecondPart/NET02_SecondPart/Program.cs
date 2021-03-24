using NET02_SecondPart.Entities;
using System;

namespace NET02_SecondPart
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var printerInformation = new ConsoleInformationPrinter();
            var incorrectLoginsGetter = new IncorrectLoginsGetter();

            var conf = XmlFile.Read("settings.xml");

            conf.PrintInformation(printerInformation);

            conf.PrintIncorrectLogins(conf.GetIncorrectLogins(incorrectLoginsGetter));

            WriteJson.WorkWithJson(conf);

            Console.ReadLine();
        }
    }
}
