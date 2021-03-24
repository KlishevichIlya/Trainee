using System.Collections.Generic;

namespace NET02_SecondPart.Interfaces
{
    public interface IIncorrectLoginsPrinter
    {
        void PrintIncorrectLogins(List<string> incorrectLogins);
    }
}
