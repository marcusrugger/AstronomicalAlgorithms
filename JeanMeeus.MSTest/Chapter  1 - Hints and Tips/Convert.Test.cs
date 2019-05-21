using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class ConvertTests
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 1, page 7
        // Test values given at bottom of page
        [TestMethod]
        public void TestSexagecimal()
        {
            double d = Convert.Sexagesimal(23, 26, 49);
            Assert.AreEqual(23.44694444, d, 0.00000001);
        }
    }
}
