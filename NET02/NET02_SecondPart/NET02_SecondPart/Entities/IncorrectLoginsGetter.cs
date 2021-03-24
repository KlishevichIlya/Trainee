using NET02_SecondPart.Interfaces;
using System;
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
                .Where(@t => @t.wn.Top == null || @t.wn.Left == null || @t.wn.Height == null || @t.wn.Width == null)
                .Select(@t => @t.login.Name)).ToList();

            Console.WriteLine(incorrectLogins.Any()
                ? "Configuration for login is incorrect."
                : "Configuration for login is correct.");

            return incorrectLogins;
        }
    }
}
