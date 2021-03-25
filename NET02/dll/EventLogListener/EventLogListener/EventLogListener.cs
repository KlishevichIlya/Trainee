using Interfaces;
using System.IO;

namespace EventLogListener
{
    public class EventLogListener : IObserver
    {
        public void Update(ISubject subject)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\EventLogMessage.evt", "This is message for Event Log.");
        }
    }
}
