using Interfaces;
using System.IO;

namespace TextListener
{
    public class TextListener : IObserver
    {
        public void Update(string message, string type) =>
             File.AppendAllText(Directory.GetCurrentDirectory() + @"\TxtMessage.txt", $"{message} || {type}\n");
    }
}
