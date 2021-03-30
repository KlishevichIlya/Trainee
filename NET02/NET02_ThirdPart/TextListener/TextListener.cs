using Interfaces;
using System.Collections.Generic;
using System.IO;

namespace TextListener
{
    public class TextListener : IObserver
    {
        public List<string> NameList { get; set; } = new List<string>();
        public List<string> ValueList { get; set; } = new List<string>();

        public void Update(string message, string type) =>
            File.AppendAllText(Directory.GetCurrentDirectory() + @"\TxtMessage.txt", $"{message} || {type}\n");
    }

}
