using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02_FirstPart.Entities;
using System;
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
                new Book("1111111111111", "A", new DateTime(2000,10,10)),
                new Book("2222222222222", "B", new DateTime(1990,10,10)),
                new Book("3333333333333", "C", new DateTime(1980,10,10))
            };
        }

        [TestMethod]
        public void SortBooksDescending_SortedNewCollection_SortedCollectionReturned()
        {
            var newCatalog = new CatalogDictionary()
            {
                new Book("2222222222222", "B",new DateTime(1990,10,10)),
                new Book("1111111111111", "A",new DateTime(2000,10,10)),
                new Book("3333333333333", "C", new DateTime(1980,10,10))
            };

            var sortedCatalog = newCatalog.SortBooksDescending();

            Assert.AreEqual(_catalog[0], sortedCatalog.ToList()[0]);
            Assert.AreEqual(_catalog[1], sortedCatalog.ToList()[1]);
            Assert.AreEqual(_catalog[2], sortedCatalog.ToList()[2]);
            // Assert.IsTrue(_catalog.SequenceEqual(newCatalog, new CatalogEqualityComparer()));
        }
    }
}
