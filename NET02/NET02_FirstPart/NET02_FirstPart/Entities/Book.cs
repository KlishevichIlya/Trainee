using System;
using System.Collections.Generic;

namespace NET02_FirstPart.Entities
{
    public class Book
    {
        private const int MaxLenght = 1000;
        public string Isbn { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name?.Length > MaxLenght)
                    throw new ArgumentException($"Argument must be less than {MaxLenght} symbols.");
                _name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException();
            }
        }
        public DateTime PublicationDate { get; set; }
        private List<Autor> _autors = new List<Autor>();

        public Book(string isbn, string name, DateTime publicationDate)
        {
            Isbn = isbn;
            Name = name;
            PublicationDate = publicationDate;
        }


    }
}
