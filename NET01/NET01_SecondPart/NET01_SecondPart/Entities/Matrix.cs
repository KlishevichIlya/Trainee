using NET01_SecondPart.Helper;
using System;
using System.Collections.Generic;

namespace NET01_SecondPart.Entities
{
    public abstract class Matrix<T>
    {
        protected T[] _data;
        public int Size { get; private set; }
        public abstract T this[int row, int col] { get; set; }

        protected virtual bool IsGenerateEvent(T OldValue, T NewValue)
        {
            if (EqualityComparer<T>.Default.Equals(OldValue, NewValue))
                return false;
            return true;
        }

        public Matrix(int Size)
        {
            Check.SizeIsPositive(Size, nameof(Size));
            this.Size = Size;
            _data = new T[Size * Size];
        }

        protected virtual void OnChangeValue(ValueEventArgs<T> e)
        {
            ChangeValue?.Invoke(this, e);
        }

        public event EventHandler<ValueEventArgs<T>> ChangeValue;
    }
}
