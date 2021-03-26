using NET02_ThirdPart.Entities;
using System;


namespace NET02_ThirdPart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new Logger();
            logger.Record("Message");

            Console.ReadKey();
        }
    }
}
