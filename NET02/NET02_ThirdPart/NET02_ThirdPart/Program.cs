using NET02_ThirdPart.Entities;
using System;


namespace NET02_ThirdPart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var subject = new Subject();
            var textListener = new TextListener.TextListener();
            var wordListener = new WordListener.WordListener();
            var evtListener = new EventLogListener.EventLogListener();

            subject.Attach(textListener);
            subject.Attach(wordListener);
            subject.Attach(evtListener);
            subject.Notify();

            Console.ReadKey();
        }
    }
}
