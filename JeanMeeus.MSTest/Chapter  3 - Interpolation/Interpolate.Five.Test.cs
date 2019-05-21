using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class InterpolateFiveTests
    {
        private double Sexagesimal(double h, double m, double s)
        {
            return Convert.Sexagecimal(h, m, s);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Example 3.e
        [TestMethod]
        public void Example3e()
        {
            var fn = new InterpolateFive(
                Sexagesimal(0, 54, 36.125),
                Sexagesimal(0, 54, 24.606),
                Sexagesimal(0, 54, 15.486),
                Sexagesimal(0, 54, 8.694),
                Sexagesimal(0, 54, 4.133));

            var n = Sexagesimal(3, 20, 0) / 12.0;
            var y = fn.FromN(n);
            Assert.AreEqual(Sexagesimal(0, 54, 13.369), y, Sexagesimal(0, 0, 0.001));
        }
    }
}
