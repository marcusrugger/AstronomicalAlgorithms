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
            var y1 = Convert.Sexagesimal(0, 54, 36.125);
            var y2 = Convert.Sexagesimal(0, 54, 24.606);
            var y3 = Convert.Sexagesimal(0, 54, 15.486);
            var y4 = Convert.Sexagesimal(0, 54, 8.694);
            var y5 = Convert.Sexagesimal(0, 54, 4.133);

            var fn = new InterpolateFive(y1, y2, y3, y4, y5);

            var n = Convert.Sexagesimal(3, 20, 0) / 12.0;
            var y = fn.FindY(n);

            var expected = Convert.Sexagesimal(0, 54, 13.369);
            var precision = Convert.Sexagesimal(0, 0, 0.001);
            Assert.AreEqual(expected, y, precision);
        }
    }
}
