using NET02_SecondPart.Interfaces;
using System;

namespace NET02_SecondPart.Entities
{
    public class ConsoleInformationPrinter : IInformationPrinter
    {
        public void PrintInformation(Configuration config)
        {
            foreach (var login in config.Logins)
            {
                Console.WriteLine(login);
                foreach (var wn in login.Windows)
                {
                    Console.WriteLine(wn);
                }
            }
        }
    }
}
