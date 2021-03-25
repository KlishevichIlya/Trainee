using Interfaces;
using System.IO;

namespace TextListener
{
    public class TextListener : IObserver
    {
        public void Update(ISubject subject) =>
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\TxtMessage.txt", "This is text message");
    }
}
