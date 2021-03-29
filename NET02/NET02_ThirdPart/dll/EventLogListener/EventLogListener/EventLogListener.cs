using Interfaces;
using System.Diagnostics;

namespace EventLogListener
{
    public class EventLogListener : IObserver
    {
        public void Update(string message, string type)
        {
            using (var eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message + " || " + type, EventLogEntryType.Information);
            }
        }
    }
}
