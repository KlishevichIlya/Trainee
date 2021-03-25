using Interfaces;
using System.IO;

namespace WordListener
{
    public class WordListener : IObserver
    {
        public void Update(ISubject subject) => File.WriteAllText(Directory.GetCurrentDirectory() + @"\WordMessage.doc",
            "This is message for word-file.");
    }
}
