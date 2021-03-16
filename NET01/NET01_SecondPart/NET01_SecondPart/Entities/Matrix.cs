using NET01_SecondPart.Helper;

namespace NET01_SecondPart.Entities
{
    public abstract class Matrix<T>
    {
        protected T[] _data;
        public int Size { get; private set; }
        public abstract T this[int row, int col] { get; set; }

        public Matrix(int Size)
        {
            Check.SizeIsPositive(Size, nameof(Size));
            this.Size = Size;
            _data = new T[Size * Size];
        }
    }
}
