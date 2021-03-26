using Interfaces;
using System.IO;

namespace WordListener
{
    public class WordListener : IObserver
    {
        public void Update(string message, string type) => File.AppendAllText(Directory.GetCurrentDirectory() + @"\WordMessage.doc",
            $"{message} || {type}\n");
    }
}
