using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NET02_FirstPart.Entities
{
    public class CatalogDictionary : KeyedCollection<string, Book>
    {
        public void ChangeTitle(Book item, string isbn)
        {
            ChangeItemKey(item, isbn);
        }

        public new IEnumerator<Book> GetEnumerator() => Items.OrderBy(e => e.Name).GetEnumerator();

        public IEnumerable<Book> GetBookByCurrentAuthor(Author currentAuthor) =>
            Items.SelectMany(item => item.Authors, (item, author) => new { item, author })
                .Where(@t => string.Equals(@t.author.FirstName, currentAuthor.FirstName,
                    StringComparison.CurrentCultureIgnoreCase))
                .Where(@t => string.Equals(@t.author.SecondName, currentAuthor.SecondName,
                    StringComparison.CurrentCultureIgnoreCase))
                .Select(@t => @t.item);

        public IEnumerable<Book> SortBooksDescending() => Items.OrderByDescending(u => u.PublicationDate);

        public IEnumerable<(Author, int)> GetStatisticsOnAuthors() =>
            Items.SelectMany(u => u.Authors)
                .GroupBy(i => i)
                .Select(i => (i.Key, i.Count()));

        protected override string GetKeyForItem(Book item) => item.Isbn;

        protected override void InsertItem(int index, Book item)
        {
            if (item == null) return;
            if (Items.Contains(item))
                throw new ArgumentException(
                    "An item with the same key has already been added. Create new key for adding your item.");
            base.InsertItem(index, item);
            item.Catalog = this;
        }

        protected override void SetItem(int index, Book item)
        {
            if (item == null) return;
            base.SetItem(index, item);
            item.Catalog = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Catalog = null;
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach (var book in this)
            {
                book.Catalog = null;
            }

            base.ClearItems();
        }
    }
}
