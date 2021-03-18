namespace NET01_SecondPart.Entities
{
    /// <summary>Class for working with diagonal matrix.</summary>
    /// <typeparam name="T">Parameter need for working with generic types.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>Gets or sets the element of diagonal matrix.</summary>
        /// <param name="row">The row of matrix element.</param>
        /// <param name="col">The column of matrix element.</param>
        /// <returns>T</returns>
        public override T this[int row, int col]
        {
            get
            {
                CheckCorrectIndex(row, col);
                return row == col ? Data[row] : default;
            }
            set
            {
                CheckCorrectIndex(row, col);
                if (row != col) return;
                var temp = Data[row];
                Data[row] = value;
                if (IsGenerateEvent(temp, value))
                {
                    OnValueChanged(new ValueEventArgs<T>(row, col, temp, value));
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="DiagonalMatrix{T}" /> class.</summary>
        /// <param name="size">The size of matrix. (Size of main diagonal).</param>
        public DiagonalMatrix(int size)
        {
            CheckCorrectSize(size);
            Size = size;
            Data = new T[size];
        }
    }
}
