using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace TestLogic
{
    [TestClass]
    public class TestLogicLayer
    {
        private readonly AbstractDataAPI dataLayer = Substitute.For<AbstractDataAPI>();

        [TestMethod]
        public void TestUsers()
        {
            AbstractLogicAPI logicLayer = AbstractLogicAPI.CreateLayer(dataLayer);
            logicLayer.AddUser("u01", "A", "A");
            dataLayer.UserExists("u01").Returns(true);
            Assert.ThrowsException<System.InvalidOperationException>(() => logicLayer.AddUser("u01", "A", "A"));
            logicLayer.RemoveUser("u01");
            dataLayer.UserExists("u01").Returns(false);
            Assert.ThrowsException<System.InvalidOperationException>(() => logicLayer.RemoveUser("u01"));
        }
        [TestMethod]
        public void TestElements()
        {
            AbstractLogicAPI logicLayer = AbstractLogicAPI.CreateLayer(dataLayer);
            logicLayer.AddElement("b01", "A", "A");
            dataLayer.ElementExists("b01").Returns(true);
            dataLayer.GetElementOccurrences("b01").Returns(new List<string>());
            Assert.ThrowsException<System.InvalidOperationException>(() => logicLayer.AddElement("b01", "A", "A"));
            logicLayer.RemoveElement("b01");
            dataLayer.ElementExists("b01").Returns(false);
            Assert.ThrowsException<System.InvalidOperationException>(() => logicLayer.RemoveElement("b01"));
        }
        [TestMethod]
        public void TestEvents()
        {
            AbstractLogicAPI logicLayer = AbstractLogicAPI.CreateLayer(dataLayer);
            dataLayer.UserExists("u01").Returns(true);
            dataLayer.ElementExists("b01").Returns(true);
            dataLayer.ElementIsAvailable("b01").Returns(false);
            Assert.ThrowsException<System.InvalidOperationException>(() => logicLayer.RentElement("b01", "u01"));
            dataLayer.ElementIsAvailable("b01").Returns(true);
            logicLayer.RentElement("b01", "u01");
            dataLayer.HasBook("b01", "u01").Returns(true);
            logicLayer.ReturnElement("b01", "u01");
            dataLayer.HasBook("b01", "u01").Returns(false);
            Assert.ThrowsException<System.InvalidOperationException>(() => logicLayer.ReturnElement("b01", "u01"));
        }
    }
}