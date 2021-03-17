using System;
using System.Collections.Generic;

namespace NET01_SecondPart.Entities
{
    /// <summary>Class for working with square matrix.</summary>
    /// <typeparam name="T">Parameter need for working with generic types.</typeparam>
    public class SquareMatrix<T>
    {
        /// <summary>The field for saving matrix elements.</summary>
        protected T[] Data;

        /// <summary>Get or set size square matrix.</summary>
        /// <value>Size must be INT type.</value>
        public int Size { get; set; }

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

        /// <summary>Allow child classes to change the constructor.</summary>
        protected SquareMatrix()
        {
        }

        /// <summary>Determines whether an event for changing a matrix element should be generated.</summary>
        /// <param name="oldValue">The old value of matrix element.</param>
        /// <param name="newValue">The new value of matrix element.</param>
        /// <returns>
        ///   <c>true if the values ​​do not match; otherwise, it is false.</c>
        /// </returns>
        protected bool IsGenerateEvent(T oldValue, T newValue) =>
            !EqualityComparer<T>.Default.Equals(oldValue, newValue);

        /// <summary>Checks the size of matrix.</summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentOutOfRangeException">Size less than zero.</exception>
        protected void CheckCorrectSize(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
        }

        /// <summary>Checks the index of the correct.</summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <exception cref="ArgumentOutOfRangeException">Row or Column less than zero. Row or Column more than he dimensions of the matrix </exception>
        protected void CheckCorrectIndex(int row, int col)
        {
            if (row < 0 || col < 0 || row > Size || col > Size) throw new ArgumentOutOfRangeException();
        }

        /// <summary>Raises the <see cref="E:ValueChanged" /> event.</summary>
        /// <param name="e">The <see cref="ValueEventArgs{T}" /> instance containing the event data.
        /// (Row, Column, Old Value, New Value)</param>
        protected virtual void OnValueChanged(ValueEventArgs<T> e) => ValueChanged?.Invoke(this, e);
    }
}
