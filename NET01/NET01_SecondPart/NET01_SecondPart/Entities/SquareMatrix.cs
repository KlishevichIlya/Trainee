using NET01_SecondPart.Helper;

namespace NET01_SecondPart.Entities
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int Size)
            : base(Size)
        {

        }

        public override T this[int row, int col]
        {
            get
            {
                Check.IsCorrectIndex(row, col);
                return _data[row * Size + col];
            }
            set
            {
                Check.IsCorrectIndex(row, col);
                _data[row * Size + col] = value;
            }
        }
    }
}
