using NET02_SecondPart.Interfaces;
using System;
using System.Collections.Generic;

namespace NET02_SecondPart.Entities
{
    public class ConsoleIncorrectLoginsPrinter : IIncorrectLoginsPrinter
    {
        public void PrintIncorrectLogins(List<string> incorrectLogins)
        {
            Console.Write("Incorrect logins: ");
            foreach (var login in incorrectLogins)
            {
                Console.Write(login + " ");
            }

            Console.WriteLine();
        }
    }
}
