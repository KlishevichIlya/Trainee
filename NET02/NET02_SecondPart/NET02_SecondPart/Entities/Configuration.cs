using NET02_SecondPart.Interfaces;
using System.Collections.Generic;

namespace NET02_SecondPart.Entities
{
    public class Configuration
    {
        public List<Login> Logins { get; set; } = new List<Login>();

        public void ChangeConfiguration(dynamic jsonObj, int i)
        {
            foreach (var lg in Logins)
            {
                for (var j = 0; j < lg.Windows.Count; j++)
                {
                    if (jsonObj["Logins"][i]["Windows"][j]["Top"] == null)
                        jsonObj["Logins"][i]["Windows"][j]["Top"] = "0";
                    if (jsonObj["Logins"][i]["Windows"][j]["Left"] == null)
                        jsonObj["Logins"][i]["Windows"][j]["Left"] = "0";
                    if (jsonObj["Logins"][i]["Windows"][j]["Width"] == null)
                        jsonObj["Logins"][i]["Windows"][j]["Width"] = "400";
                    if (jsonObj["Logins"][i]["Windows"][j]["Height"] == null)
                        jsonObj["Logins"][i]["Windows"][j]["Height"] = "150";
                }
            }
        }

        public bool IsCorrectConfiguration(IConfigurationChecker configurationChecker) =>
            configurationChecker.IsCorrectConfiguration(Logins);

        public void PrintIncorrectLogins(IIncorrectLoginsPrinter incorrectLoginsPrinter, List<string> incorrectLogins)
        {
            incorrectLoginsPrinter.PrintIncorrectLogins(incorrectLogins);
        }

        public void PrintInformation(IInformationPrinter informationPrinter)
        {
            informationPrinter.PrintInformation(this);
        }

        public List<string> GetIncorrectLogins(IIncorrectLoginsGetter incorrectLogins)
        {
            return incorrectLogins.GetIncorrectLogins(this);
        }
    }
}
