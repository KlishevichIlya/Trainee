using NET02_FirstPart.Entities;
using System;
using System.Collections.Generic;

namespace NET02_FirstPart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var alan = new Author("Alan", "Cooper");
            var bob = new Author("Bob", "Smith");

            var authorsOfFirst = new List<Author>
            {
                alan,
                bob
            };
            var authorsOfSecond = new List<Author>
            {
                alan
            };

            var catalog = new CatalogDictionary
            {
                new Book("111-1-11-111111-1", "The catcher in the rye", DateTime.Now, authorsOfFirst),
                new Book("3333333333333", "The great Gatsby", new DateTime(1987, 05, 05), authorsOfSecond),
                new Book("1111111111111", "The catcher", DateTime.Now, authorsOfFirst),
            };
            Console.WriteLine(catalog["111-1-11-111111-1".Replace("-", "")].Name);
            Console.WriteLine(catalog["1111111111111"].Name);

            Console.WriteLine("***");
            foreach (var item in catalog.GetBookByCurrentAuthor(new Author("ALAN", "COOPER")))
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("***");


            foreach (var item in catalog.SortBooksDescending())
            {
                Console.WriteLine(item.PublicationDate);
            }

            Console.WriteLine();

            foreach (var (author, count) in catalog.GetStatisticsOnAuthors())
            {
                Console.Write(author.FirstName + " " + author.SecondName + " ");
                Console.WriteLine(count);
                Console.WriteLine();
            }

            Console.WriteLine(catalog[0].Equals(catalog[1]));
            Console.ReadKey();
        }
    }
}
