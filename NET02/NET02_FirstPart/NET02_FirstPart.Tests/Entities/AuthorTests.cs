using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02_FirstPart.Entities;
using System;

namespace NET02_FirstPart.Tests.Entities
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("   ", "   ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_CallWithWrongParameters_ExceptionThrown(string firstName, string secondName)
        {
            new Author(firstName, secondName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_CallWithTooLongFirstName_ExceptionThrown()
        {
            var firstName = new string('a', 201);
            new Author(firstName, "Second Name");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_CallWithTooLongSecondName_ExceptionThrown()
        {
            var secondName = new string('a', 201);
            new Author("First Name", secondName);
        }

        [TestMethod]
        public void Ctor_CheckLengthParameters_OkReturned()
        {
            var expectedFirstName = "John";
            var expectedSecondName = "Martin";

            var author = new Author("John", "Martin");

            Assert.AreEqual(expectedFirstName, author.FirstName, true);
            Assert.AreEqual(expectedSecondName, author.SecondName, true);
        }
    }
}
