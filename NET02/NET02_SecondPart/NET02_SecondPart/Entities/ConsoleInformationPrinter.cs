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
    }
}
