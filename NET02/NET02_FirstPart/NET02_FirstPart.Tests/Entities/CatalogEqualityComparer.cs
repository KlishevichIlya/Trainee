using NET02_FirstPart.Entities;
using System.Collections.Generic;

namespace NET02_FirstPart.Tests.Entities
{
    public class CatalogEqualityComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y) => y != null && x != null && (ReferenceEquals(x, y) || x.Isbn == y.Isbn);

        public int GetHashCode(Book obj) => obj.Isbn.GetHashCode();
    }
}
