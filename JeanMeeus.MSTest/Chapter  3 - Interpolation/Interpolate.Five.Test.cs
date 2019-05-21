using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class InterpolateFiveTests
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Example 3.e
        [TestMethod]
        public void Example3e()
        {
            var fn = new InterpolateFive(
                Convert.Sexagesimal(0, 54, 36.125),
                Convert.Sexagesimal(0, 54, 24.606),
                Convert.Sexagesimal(0, 54, 15.486),
                Convert.Sexagesimal(0, 54, 8.694),
                Convert.Sexagesimal(0, 54, 4.133));

            var n = Convert.Sexagesimal(3, 20, 0) / 12.0;
            var y = fn.FromN(n);

            var expected = Convert.Sexagesimal(0, 54, 13.369);
            var precision = Convert.Sexagesimal(0, 0, 0.001);
            Assert.AreEqual(expected, y, precision);
        }
    }
}
