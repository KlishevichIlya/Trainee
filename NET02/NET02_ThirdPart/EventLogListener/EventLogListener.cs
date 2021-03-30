using Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace EventLogListener
{
    public class EventLogListener : IObserver
    {
        public List<string> NameList { get; set; } = new List<string>();
        public List<string> ValueList { get; set; } = new List<string>();

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
