using System.Collections.Generic;

namespace NET02_SecondPart.Entities
{
    public class Login
    {
        public string Name { get; set; }
        public List<Window> Windows { get; set; } = new List<Window>();
    }
}
