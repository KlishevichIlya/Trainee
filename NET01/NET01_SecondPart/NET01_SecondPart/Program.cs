using NET01_SecondPart.Entities;
using System;

namespace NET01_SecondPart
{
    class Program
    {
        static void Main(string[] args)
        {
            var diagonal = new DiagonalMatrix<string>(3);
            var square = new SquareMatrix<float>(3);
            square[1, 1] = 1.2F;
            square[1, 2] = 6.2F;
            diagonal[0, 0] = "5";
            diagonal[1, 1] = "4";
            diagonal[2, 2] = "4";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(square[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
