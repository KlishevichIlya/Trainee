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

            var myClass = new MyClass("Ivan", 25);
            logger.Track(myClass);


            Console.ReadKey();
        }
    }
}
