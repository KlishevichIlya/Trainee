using NET01_SecondPart.Entities;
using System;

namespace NET01_SecondPart
{
    /// <summary>The class from which the program starts.</summary>
    public class Program
    {
        /// <summary>A common method to handle the events.</summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ValueEventArgs{T}" /> instance containing the event data.</param>
        public static void Reaction<T>(object sender, ValueEventArgs<T> e)
        {
            Console.WriteLine($"Row : {e.Col}");
            Console.WriteLine($"Col : {e.Row}");
            Console.WriteLine($"Old : {e.OldValue}");
            Console.WriteLine($"New : {e.NewValue}");
        }

        /// <summary>Prints the matrix.</summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="currentArray">The array for output.</param>
        public static void PrintMatrix<T>(SquareMatrix<T> currentArray)
        {
            for (var i = 0; i < currentArray.Size; i++)
            {
                for (var j = 0; j < currentArray.Size; j++)
                {
                    Console.Write(currentArray[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>This is the entry point of the C # application</summary>
        /// <param name="args">The command line arguments</param>
        public static void Main(string[] args)
        {
            var square = new SquareMatrix<int>(3);
            var diagonal = new DiagonalMatrix<string>(-1);
            var otherDiagonal = new DiagonalMatrix<string>(4);

            square.ValueChanged += Reaction;
            diagonal.ValueChanged += delegate (object sender, ValueEventArgs<string> e)
            {
                Console.WriteLine($"Row : {e.Col}");
                Console.WriteLine($"Col : {e.Row}");
                Console.WriteLine($"Old : {e.OldValue}");
                Console.WriteLine($"New : {e.NewValue}");
            };
            otherDiagonal.ValueChanged += (sender, e) =>
            {
                Console.WriteLine($"Row : {e.Col}");
                Console.WriteLine($"Col : {e.Row}");
                Console.WriteLine($"Old : {e.OldValue}");
                Console.WriteLine($"New : {e.NewValue}");
            };

            square[1, 1] = 1;
            square[1, 2] = 0;
            diagonal[0, 0] = "5";
            diagonal[1, 1] = "4";
            diagonal[2, 2] = "4";
            otherDiagonal[0, 0] = "3";
            otherDiagonal[1, 1] = "2";
            otherDiagonal[2, 2] = "5";
            otherDiagonal[3, 3] = "7";


            PrintMatrix(square);
            PrintMatrix(diagonal);
            PrintMatrix(otherDiagonal);

            Console.ReadKey();
        }
    }
}
