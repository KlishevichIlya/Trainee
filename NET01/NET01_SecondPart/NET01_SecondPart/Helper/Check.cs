using System;

namespace NET01_SecondPart.Helper
{
    public static class Check
    {
        public static void SizeIsPositive(int size, string argumentName = "")
        {
            if (size > 0)
                return;

            if (string.IsNullOrEmpty(argumentName))
                throw new ArgumentNullException();

            throw new ArgumentNullException(argumentName);
        }

        public static void IsDiagonalElement(int row, int col)
        {
            if (row != col)
                throw new ArgumentException("For diagonal matrix indices for writing must be equal.");
        }

        public static void IsCorrectIndex(int row, int col)
        {
            if (row < 0 || col < 0)
                throw new ArgumentException("Incorrect indices.");
        }
    }
}
