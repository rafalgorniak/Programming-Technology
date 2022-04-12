using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class TestLayerMethods
    {
        [TestMethod]
        public void TestUsers()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayer();
            dataLayer.AddUser(new User("01", "Name", "Surname"));
            Assert.IsTrue(dataLayer.UserExists("01"));
            Assert.IsFalse(dataLayer.UserExists("02"));
            dataLayer.RemoveUser("01");
            Assert.IsFalse(dataLayer.UserExists("01"));
        }
        [TestMethod]
        public void TestBooks()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayer();
            dataLayer.AddBook(new Book("01", "Les Miserables", "Victor Hugo"));
            Assert.IsTrue(dataLayer.BookExists("01"));
            Assert.IsFalse(dataLayer.BookExists("02"));
            dataLayer.RemoveElement("01");
            Assert.IsFalse(dataLayer.BookExists("01"));
        }

        [TestMethod]
        public void TestStates()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayer();
            dataLayer.AddBook(new Book("01", "Les Miserables", "Victor Hugo"));
            Assert.IsFalse(dataLayer.ElementIsAvailable("01"));
            dataLayer.AddElementOccurrence(new State(dataLayer.GetBook("01"), "01/1"));
            Assert.IsTrue(dataLayer.ElementIsAvailable("01"));
            dataLayer.AddElementOccurrence(new State(dataLayer.GetBook("01"), "01/2"));
            Assert.AreEqual(dataLayer.GetElementOccurrences("01").Count, 2);
            dataLayer.RemoveElementOccurrence("01/1");
            dataLayer.RemoveElementOccurrence("01/2");
            Assert.IsFalse(dataLayer.ElementIsAvailable("01"));
        }
        [TestMethod]
        public void TestEvents()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayer();
            dataLayer.AddUser(new User("u01", "Name", "Surname"));
            dataLayer.AddBook(new Book("b01", "Les Miserables", "Victor Hugo"));
            dataLayer.AddElementOccurrence(new State(dataLayer.GetBook("b01"), "01/1"));
            dataLayer.AddElementOccurrence(new State(dataLayer.GetBook("b01"), "01/2"));
            dataLayer.RentElement(new Rental(dataLayer.GetUser("u01"), dataLayer.WhichBookIsAvailable("b01")));
            dataLayer.MakeBookAvailable(dataLayer.GetState("01/1"), false);
            Assert.IsTrue(dataLayer.HasBook("b01", "u01"));
            Assert.AreEqual(dataLayer.WhichBookHas("b01", "u01"), dataLayer.GetState("01/1"));
            Assert.IsTrue(dataLayer.ElementIsAvailable("b01"));
            dataLayer.RemoveElementOccurrence("01/2");
            Assert.IsFalse(dataLayer.ElementIsAvailable("b01"));
            dataLayer.ReturnElement(new Return(dataLayer.GetUser("u01"), dataLayer.WhichBookHas("b01", "u01")));
            dataLayer.MakeBookAvailable(dataLayer.GetState("01/1"), true);
            Assert.IsFalse(dataLayer.HasBook("b01", "u01"));
            Assert.IsTrue(dataLayer.ElementIsAvailable("b01"));
        }
    }
}