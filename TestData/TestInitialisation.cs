using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class TestInitialisation
    {
        [TestMethod]
        public void TestConstantInitialisation()
        {
            AbstractDataAPI dataLayer = AbstractDataAPI.CreateDataLayer(new ConstantInitialiser());
            Assert.IsTrue(dataLayer.UserExists("u03"));
            Assert.IsFalse(dataLayer.UserExists("b01"));
            Assert.IsTrue(dataLayer.BookExists("b04"));
            Assert.IsTrue(dataLayer.ElementIsAvailable("b01"));
            Assert.AreEqual(dataLayer.GetElementOccurrences("b01").Count, 3);
        }
        [TestMethod]
        public void TestXmlInitialisation()
        {
            AbstractDataAPI dataLayer = AbstractDataAPI.CreateDataLayer(new XmlInitialiser());
            Assert.IsTrue(dataLayer.UserExists("u03"));
            Assert.IsFalse(dataLayer.UserExists("b01"));
            Assert.IsTrue(dataLayer.BookExists("b04"));
            Assert.IsTrue(dataLayer.ElementIsAvailable("b01"));
            Assert.AreEqual(dataLayer.GetElementOccurrences("b01").Count, 3);
        }
    }
}