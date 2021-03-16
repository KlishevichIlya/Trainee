
using NET01_SecondPart.Helper;

namespace NET01_SecondPart.Entities
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int Size)
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
                Check.IsDiagonalElement(row, col);
                T temp = _data[row * Size + col];
                _data[row * Size + col] = value;
                if (IsGenerateEvent(temp, value))
                {
                    OnChangeValue(new ValueEventArgs<T>(row, col, temp, value));
                }
            }
        }
    }
}
