using NUnit.Framework;
using POSTerminal.Services;
using System;

namespace POSTerminal.Tests.Services
{
    [TestFixture]
    public class PointOfSaleTerminalTest
    {
        private PointOfSaleTerminal posTerminal;
        [SetUp]
        public void Setup()
        {
            posTerminal = new PointOfSaleTerminal();
            posTerminal.SetPricing();
        }

        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6)]
        [TestCase("ABCD", 7.25)]
        [TestCase("CCCCCC", 5)]
        public void CalculateTotalTest(string products, decimal expectedResult)
        {
            //Arrange
            foreach (char productCode in products)
            {
                posTerminal.Scan(productCode.ToString());
            }

            //Act
            decimal actualResult = posTerminal.CalculateTotal();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("E", true)]
        [TestCase("A", false)]
        public void ScanTest(string productCode, bool throwsException)
        {
            if (throwsException)
            {
                Assert.Throws<Exception>(() => posTerminal.Scan(productCode.ToString()), "Invalid product code!");
            }
            else
            {
                Assert.DoesNotThrow(() => posTerminal.Scan(productCode));
            }
        }
    }
}