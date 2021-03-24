using NET02_SecondPart.Interfaces;
using System;
using System.Collections.Generic;

namespace NET02_SecondPart.Entities
{
    public class Configuration
    {
        public List<Login> Logins { get; set; } = new List<Login>();

        public void PrintIncorrectLogins(List<string> incorrectLogins)
        {
            Console.Write("Incorrect logins: ");
            foreach (var login in incorrectLogins)
            {
                Console.Write(login + "");
            }

            Console.WriteLine();
        }

        public void PrintInformation(IInformationPrinter informationPrinter)
        {
            informationPrinter.PrintInformation(this);
        }

        public List<string> GetIncorrectLogins(IIncorrectLoginsGetter incorrectLogins)
        {
            return incorrectLogins.GetIncorrectLogins(this);
        }
    }
}
