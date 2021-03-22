using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NET02_FirstPart.Entities
{
    public class Book
    {
        private const int MaxLength = 1000;
        private readonly string _pattern = @"^\d{3}-\d{1}-\d{2}-\d{6}-\d{1}|^\d{13}";

        private string _isbn;
        private string _name;

        public string Isbn
        {
            get => _isbn;
            set
            {
                _isbn = Regex.IsMatch(value, _pattern)
                    ? value.Replace(@"-", "")
                    : throw new ArgumentException("The ISBN is in the wrong format");
                Catalog?.ChangeTitle(this, value);
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value?.Length > MaxLength)
                    throw new ArgumentException($"Argument must be less than {MaxLength} symbols.");
                _name = (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                    ? value
                    : throw new ArgumentException();
            }
        }

        public DateTime? PublicationDate { get; set; }

        public CatalogDictionary Catalog { get; set; }

        public List<Author> Authors { get; }

        public Book(string isbn, string name, DateTime? publicationDate = null, List<Author> collection = null)
        {
            Isbn = isbn;
            Name = name;
            PublicationDate = publicationDate;
            Authors = collection;
        }

        public override bool Equals(object obj) =>
            (obj is Book book) && book.Isbn == Isbn;

        public override int GetHashCode() => Isbn.GetHashCode();
    }
}
