using NET02_SecondPart.Entities;
using System.Collections.Generic;

namespace NET02_SecondPart.Interfaces
{
    public interface IConfigurationChecker
    {
        bool IsCorrectConfiguration(List<Login> loginsList);
    }
}
