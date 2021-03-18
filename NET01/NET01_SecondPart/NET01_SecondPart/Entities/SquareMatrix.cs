using System;
using System.Collections.Generic;

namespace NET01_SecondPart.Entities
{
    /// <summary>Class for working with square matrix.</summary>
    /// <typeparam name="T">Parameter need for working with generic types.</typeparam>
    public class SquareMatrix<T>
    {
        protected T[] Data;

        /// <summary>Get or set size square matrix.</summary>
        /// <value>Size must be INT type.</value>
        public int Size { get; protected set; }

        /// <summary>Gets or sets the element of matrix.</summary>
        /// <param name="row">The row of matrix element.</param>
        /// <param name="col">The column of matrix element.</param>
        /// <returns>T</returns>
        public virtual T this[int row, int col]
        {
            get
            {
                CheckCorrectIndex(row, col);
                return Data[row * Size + col];
            }
            set
            {
                CheckCorrectIndex(row, col);
                var temp = Data[row * Size + col];
                Data[row * Size + col] = value;
                if (IsGenerateEvent(temp, value)) OnValueChanged(new ValueEventArgs<T>(row, col, temp, value));
            }
        }

        /// <summary>Occurs when matrix element is changed.</summary>
        public event EventHandler<ValueEventArgs<T>> ValueChanged;

        /// <summary>Initializes a new instance of the <see cref="SquareMatrix{T}" /> class.</summary>
        /// <param name="size">The size of matrix.</param>
        public SquareMatrix(int size)
        {
            CheckCorrectSize(size);
            Size = size;
            Data = new T[size * size];
        }

        protected SquareMatrix()
        {
        }

        protected bool IsGenerateEvent(T oldValue, T newValue) =>
            !EqualityComparer<T>.Default.Equals(oldValue, newValue);

        protected void CheckCorrectSize(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
        }

        protected void CheckCorrectIndex(int row, int col)
        {
            if (row < 0 || col < 0 || row > Size || col > Size) throw new ArgumentOutOfRangeException();
        }

        protected virtual void OnValueChanged(ValueEventArgs<T> e) => ValueChanged?.Invoke(this, e);
    }
}
