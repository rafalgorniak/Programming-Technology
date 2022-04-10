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
            var dataLayer = AbstractDataAPI.CreateDataLayerEmpty();
            dataLayer.AddUser("01", "Name", "Surname");
            Assert.IsTrue(dataLayer.UserExists("01"));
            Assert.IsFalse(dataLayer.UserExists("02"));
            dataLayer.RemoveUser("01");
            Assert.IsFalse(dataLayer.UserExists("01"));
        }
        [TestMethod]
        public void TestBooks()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayerEmpty();
            dataLayer.AddElement("01", "Les Miserables", "Victor Hugo");
            Assert.IsTrue(dataLayer.ElementExists("01"));
            Assert.IsFalse(dataLayer.ElementExists("02"));
            dataLayer.RemoveElement("01");
            Assert.IsFalse(dataLayer.ElementExists("01"));
        }

        [TestMethod]
        public void TestStates()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayerEmpty();
            dataLayer.AddElement("01", "Les Miserables", "Victor Hugo");
            Assert.IsFalse(dataLayer.ElementIsAvailable("01"));
            dataLayer.AddElementOccurrence("01/1", "01");
            Assert.IsTrue(dataLayer.ElementIsAvailable("01"));
            dataLayer.AddElementOccurrence("01/2", "01");
            Assert.AreEqual(dataLayer.GetElementOccurrences("01").Count, 2);
            dataLayer.RemoveElementOccurrence("01/1");
            dataLayer.RemoveElementOccurrence("01/2");
            Assert.IsFalse(dataLayer.ElementIsAvailable("01"));
        }
        [TestMethod]
        public void TestEvents()
        {
            var dataLayer = AbstractDataAPI.CreateDataLayerEmpty();
            dataLayer.AddUser("u01", "Name", "Surname");
            dataLayer.AddElement("b01", "Les Miserables", "Victor Hugo");
            dataLayer.AddElementOccurrence("b01/1", "b01");
            dataLayer.AddElementOccurrence("b01/2", "b01");
            dataLayer.RentElement("b01", "u01");
            dataLayer.MakeElementAvailable("b01/1", false);
            Assert.IsTrue(dataLayer.HasBook("b01", "u01"));
            Assert.AreEqual(dataLayer.WhichBookHas("b01", "u01"), "b01/1");
            Assert.IsTrue(dataLayer.ElementIsAvailable("b01"));
            dataLayer.RemoveElementOccurrence("b01/2");
            Assert.IsFalse(dataLayer.ElementIsAvailable("b01"));
            dataLayer.ReturnElement("b01/1", "u01");
            dataLayer.MakeElementAvailable("b01/1", true);
            Assert.IsFalse(dataLayer.HasBook("b01", "u01"));
            Assert.IsTrue(dataLayer.ElementIsAvailable("b01"));
        }
    }
}