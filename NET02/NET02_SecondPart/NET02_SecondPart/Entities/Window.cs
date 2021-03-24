namespace NET02_SecondPart.Entities
{
    public class Window
    {
        public string Title { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public bool IsWindowCorrect()
        {
            if (Title != "main") return true;
            return Top != null && Left != null && Width != null && Height != null;
        }

        public void Fix()
        {
            if (Top == null)
                Top = 0;
            if (Left == null)
                Left = 0;
            if (Width == null)
                Width = 400;
            if (Height == null)
                Height = 150;
        }

        public override string ToString() =>
            $"\t{Title}({(Top == null ? "?" : Top.ToString())},{(Left == null ? "?" : Left.ToString())},{(Width == null ? "?" : Width.ToString())},{(Height == null ? "?" : Height.ToString())})\n";
    }
}
