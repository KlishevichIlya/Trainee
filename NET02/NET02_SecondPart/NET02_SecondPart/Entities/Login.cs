using System.Collections.Generic;
using System.Linq;

namespace NET02_SecondPart.Entities
{
    public class Login
    {
        public string Name { get; set; }
        public List<Window> Windows { get; set; } = new List<Window>();

        public bool IsLoginCorrect() => Windows.All(wn => wn.IsWindowCorrect());

        public void Fix()
        {
            foreach (var window in Windows)
            {
                window.Fix();
            }
        }

        public override string ToString() => $"{Name}\n";
    }
}
