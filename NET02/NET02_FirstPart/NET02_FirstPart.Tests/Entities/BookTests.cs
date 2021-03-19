using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02_FirstPart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NET02_FirstPart.Tests.Entities
{
    [TestClass]
    public class BookTests
    {
        private static List<Author> _authors;

        [ClassInitialize]
        public static void InitializeCurrentTest(TestContext testContext)
        {
            _authors = new List<Author>
            {
                new Author("Arnold", "Told"),
                new Author("Tim", "Cooper")
            };
        }

        [TestMethod]
        public void Ctor_CheckAllParameters_OkReturned()
        {
            var expectedIsbn = "1111111111111";
            var expectedName = "Book 1";
            var expectedDate = new DateTime(2021, 10, 10);
            var expectedAuthors = new List<Author>
            {
                new Author("Arnold", "Told"),
                new Author("Tim", "Cooper")
            };

            var book = new Book("1111111111111", "Book 1", new DateTime(2021, 10, 10), _authors);

            Assert.AreEqual(expectedIsbn, book.Isbn);
            Assert.AreEqual(expectedName, book.Name);
            Assert.AreEqual(expectedDate, book.PublicationDate);
            Assert.AreEqual(expectedAuthors.Count(), book.Authors.Count());
        }

        [TestMethod]
        public void Ctor_CheckRequiredParameters_OkReturned()
        {
            var expectedIsbn = "1111111111111";
            var expectedName = "Book 1";
            DateTime? expectedDate = null;
            List<Author> expectedAuthors = null;

            var book = new Book("1111111111111", "Book 1");

            Assert.AreEqual(expectedIsbn, book.Isbn);
            Assert.AreEqual(expectedName, book.Name);
            Assert.AreEqual(expectedDate, book.PublicationDate);
            Assert.AreEqual(expectedAuthors, book.Authors);
        }

        [TestMethod]
        public void Equals_FirstBookEqualsSecondBook_OkReturned()
        {
            var book1 = new Book("1111111111111", "Book 1");
            var book2 = new Book("111-1-11-111111-1", "Book 2");

            Assert.AreEqual(book1, book2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_CallWithWrongIsbn_ExceptionThrown()
        {
            new Book("1", "Book");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("      ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_CallWithWrongName_ExceptionThrown(string name)
        {
            new Book("1111111111111", name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_CallWithTooLong_ExceptionThrown()
        {
            var name = new string('a', 1001);
            var book = new Book("1111111111111", name);
        }

    }
}
