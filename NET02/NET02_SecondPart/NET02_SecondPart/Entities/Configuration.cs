using System.Collections.Generic;
using System.Linq;

namespace NET02_SecondPart.Entities
{
    public class Configuration
    {
        public List<Login> Logins { get; set; } = new List<Login>();

        public bool IsCorrectConfiguration() => Logins.All(login => login.IsLoginCorrect());

        public void Fix()
        {
            foreach (var login in Logins)
            {
                login.Fix();
            }
        }

        public override string ToString()
        {
            var result = "";
            foreach (var login in Logins)
            {
                result += "Login: " + login;
                result = login.Windows.Aggregate(result, (current, wn) => current + wn);
            }

            return result;
        }

        public List<Login> GetIncorrectLogins() => Logins.Where(login => !login.IsLoginCorrect()).ToList();
    }
}
