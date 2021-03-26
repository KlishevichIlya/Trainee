using Interfaces;
using System.IO;

namespace EventLogListener
{
    public class EventLogListener : IObserver
    {
        public void Update(string message, string type) =>
            File.AppendAllText(Directory.GetCurrentDirectory() + @"\EventLogMessage.evt", $"{message} || {type}\n");
    }
}
