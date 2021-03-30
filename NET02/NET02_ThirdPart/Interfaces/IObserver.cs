using System.Collections.Generic;

namespace Interfaces
{
    public interface IObserver
    {
        List<string> NameList { get; set; }
        List<string> ValueList { get; set; }
        void Update(string message, string type);
    }
}
