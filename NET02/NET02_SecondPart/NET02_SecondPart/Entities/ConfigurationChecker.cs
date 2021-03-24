using NET02_SecondPart.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NET02_SecondPart.Entities
{
    public class ConfigurationChecker : IConfigurationChecker
    {
        public bool IsCorrectConfiguration(List<Login> loginsList) =>
            loginsList.All(login => login.IsLoginCorrect(login));
    }
}
