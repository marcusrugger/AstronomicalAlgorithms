using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class BinarySearchTests
    {
        const double PRECISION = 0.000000001;

        // Astronomical Algorithms by Jean Meeus, Chapter 5, page 48, Example 5.b
        [TestMethod]
        public void TestBinarySearchExample5b()
        {
            var biterator = BinarySearch.Create(0, 1, PRECISION);
            var result = biterator((x) => Math.Pow(x, 5) + 17 * x - 8);

            double expected = 0.469249878;
            Assert.AreEqual(expected, result, PRECISION);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 5, page 49, Example 5.c
        [TestMethod]
        public void TestBinarySearchExample5c()
        {
            var biterator = BinarySearch.Create(1, 2, PRECISION);
            var result = biterator((x) => Math.Pow(x, 5) + 3 * x - 8);

            double expected = 1.321785627;
            Assert.AreEqual(expected, result, PRECISION);
        }

        [TestMethod]
        public void TestBinarySearchSquareRoot2()
        {
            var biterator = BinarySearch.Create(1, 2, PRECISION);
            var result = biterator((x) => x * x - 2);

            double expected = Math.Sqrt(2.0);
            Assert.AreEqual(expected, result, PRECISION);
        }
    }
}
