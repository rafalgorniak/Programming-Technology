using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CalculatorNS.Calculator calculator = new CalculatorNS.Calculator();
            Assert.AreEqual(calculator.Add(2, 3), 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CalculatorNS.Calculator calculator = new CalculatorNS.Calculator();
            Assert.AreEqual(calculator.Substract(2, 3.5), -1.5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            CalculatorNS.Calculator calculator = new CalculatorNS.Calculator();
            Assert.AreEqual(calculator.Multiply(-2, -3.5), 7);
        }

        [TestMethod]
        public void TestMethod4()
        {
            CalculatorNS.Calculator calculator = new CalculatorNS.Calculator();
            Assert.AreEqual(calculator.Divide(2, -0.5), -4);
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(0, 0));
        }
    }
}