using System.Collections.Generic;
using System.Linq;

namespace NET02_SecondPart.Entities
{
    public class Login
    {
        public string Name { get; set; }
        public List<Window> Windows { get; set; } = new List<Window>();

        public bool IsLoginCorrect(Login login) => login.Windows.All(window => window.IsWindowCorrect(window));

        public override string ToString() => $"Login : {Name}";
    }
}
