using System;

namespace NET01_SecondPart.Entities
{
    public class ValueEventArgs<T> : EventArgs
    {
        public int Col { get; private set; }
        public int Row { get; private set; }

        public T OldValue { get; private set; }

        public T NewValue { get; private set; }
        public ValueEventArgs(int row, int col, T oldvalue, T newvalue)
        {
            Row = row;
            Col = col;
            OldValue = oldvalue;
            NewValue = newvalue;
        }
    }
}
