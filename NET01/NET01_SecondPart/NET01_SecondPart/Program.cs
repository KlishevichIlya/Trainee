using NET01_SecondPart.Entities;
using System;

namespace NET01_SecondPart
{
    public class Program
    {
        public static void Reaction<T>(object sender, ValueEventArgs<T> e)
        {
            Console.WriteLine($"Row : {e.Col}");
            Console.WriteLine($"Col : {e.Row}");
            Console.WriteLine($"Old : {e.OldValue}");
            Console.WriteLine($"New : {e.NewValue}");
        }

        static void Main(string[] args)
        {
            var diagonal = new DiagonalMatrix<string>(3);
            var square = new SquareMatrix<int>(3);
            square.ChangeValue += Reaction;
            square[1, 1] = 1;
            square[1, 2] = 0;
            diagonal[0, 0] = "5";
            diagonal[1, 1] = "4";
            diagonal[2, 2] = "4";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(square[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
