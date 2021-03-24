using NET02_SecondPart.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NET02_SecondPart.Entities
{
    public class IncorrectLoginsGetter : IIncorrectLoginsGetter
    {
        public List<string> GetIncorrectLogins(Configuration config)
        {
            var incorrectLogins = (config.Logins.SelectMany(login => login.Windows, (login, wn) => new { login, wn })
                .Where(@t => @t.wn.Title == "main")
                .Where(@t => @t.wn.Top == 0 || @t.wn.Left == 0 || @t.wn.Height == 0 || @t.wn.Width == 0)
                .Select(@t => @t.login.Name)).ToList();

            return incorrectLogins;
        }
    }
}
