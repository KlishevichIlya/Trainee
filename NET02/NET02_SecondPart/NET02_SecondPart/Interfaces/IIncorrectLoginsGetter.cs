using NET02_SecondPart.Entities;
using System.Collections.Generic;

namespace NET02_SecondPart.Interfaces
{
    public interface IIncorrectLoginsGetter
    {
        List<string> GetIncorrectLogins(Configuration config);
    }
}
