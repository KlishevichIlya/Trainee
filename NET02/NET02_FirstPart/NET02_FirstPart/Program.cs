using NET02_FirstPart.Entities;
using System;

namespace NET02_FirstPart
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var book = new Book("123", "     ", DateTime.Now);

            Console.ReadKey();
        }
    }
}
