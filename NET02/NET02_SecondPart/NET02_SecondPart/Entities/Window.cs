namespace NET02_SecondPart.Entities
{
    public class Window
    {
        public string Title { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsWindowCorrect(Window window)
        {
            if (window.Title != "main") return true;
            return window.Top != 0 && window.Left != 0 && window.Width != 0 && window.Height != 0;
        }

        public override string ToString() =>
            $"\t{Title}({(Top == 0 ? "?" : Top.ToString())},{(Left == 0 ? "?" : Left.ToString())},{(Width == 0 ? "?" : Width.ToString())},{(Height == 0 ? "?" : Height.ToString())})";
    }
}
