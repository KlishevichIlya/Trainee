using NET02_SecondPart.Entities;
using System;

namespace NET02_SecondPart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var conf = XmlFile.Read("settings.xml");

            XmlFile.PrintInformation(conf);

            var incorrectLogins = XmlFile.CheckConfiguration(conf);

            XmlFile.PrintIncorrectLogin(incorrectLogins);

            WriteJson.WorkWithJson(conf);

            Console.ReadLine();
        }
    }
}
