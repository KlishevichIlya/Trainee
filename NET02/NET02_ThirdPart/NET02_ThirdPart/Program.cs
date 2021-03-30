using NET02_ThirdPart.Entities;
using NET02_ThirdPart.Loader;
using System;


namespace NET02_ThirdPart
{
    public class Program
    {
        static Program()
        {
            Resolver.RegisterDependencyResolver();
        }

        public static void Main(string[] args)
        {
            var logger = new Logger.Logger();
            logger.Trace("Message");
            logger.Fatal("Fatal");

            var myClass = new MyClass("Ivan", 25);
            logger.Track(myClass);

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
