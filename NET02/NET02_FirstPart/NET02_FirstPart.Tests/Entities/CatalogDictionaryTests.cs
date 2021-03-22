using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02_FirstPart.Entities;
using System.Linq;

namespace NET02_FirstPart.Tests.Entities
{
    [TestClass]
    public class CatalogDictionaryTests
    {
        private static CatalogDictionary _catalog;

        [ClassInitialize]
        public static void InitializeCurrentTest(TestContext testContext)
        {
            _catalog = new CatalogDictionary()
            {
                new Book("1111111111111", "A"),
                new Book("2222222222222", "B"),
                new Book("3333333333333", "C")
            };
        }

        [TestMethod]
        public void SortBooksDescending_SortedNewCollection_SortedCollectionReturned()
        {
            var newCatalog = new CatalogDictionary()
            {
                new Book("2222222222222", "B"),
                new Book("1111111111111", "A"),
                new Book("3333333333333", "C")
            };

            var sortedCatalog = newCatalog.SortBooksDescending();

            CollectionAssert.AreEqual(sortedCatalog.ToList(), _catalog);
            // Assert.IsTrue(_catalog.SequenceEqual(newCatalog, new CatalogEqualityComparer()));
        }
    }
}
