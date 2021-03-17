using System;

namespace NET01_SecondPart.Entities
{
    /// <summary>This class contains information about event.</summary>
    /// <typeparam name="T">Parameter need for working with generic types.</typeparam>
    public class ValueEventArgs<T> : EventArgs
    {
        /// <summary>Gets the column that changed.</summary>
        /// <value>Col must be INT type.</value>
        public int Col { get; }

        /// <summary>Gets the row that changed.</summary>
        /// <value>Row must be INT type.</value>
        public int Row { get; }

        /// <summary>Gets the old value of matrix element.</summary>
        /// <value>OldValue must be INT type.</value>
        public T OldValue { get; }

        /// <summary>Gets the new value of matrix element.</summary>
        /// <value>NewValue must be INT type.</value>
        public T NewValue { get; }

        /// <summary>Initializes a new instance of the <see cref="ValueEventArgs{T}" /> class.</summary>
        /// <param name="row">The row of matrix element.</param>
        /// <param name="col">The col of matrix element.</param>
        /// <param name="oldValue">The old value of matrix element.</param>
        /// <param name="newValue">The new value of matrix element.</param>
        public ValueEventArgs(int row, int col, T oldValue, T newValue)
        {
            Row = row;
            Col = col;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
