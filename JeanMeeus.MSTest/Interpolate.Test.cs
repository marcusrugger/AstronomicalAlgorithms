using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class InterpolateTests
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Example 3.a
        [TestMethod]
        public void Example3a()
        {
            var fn = Interpolator.FromN(0.884226, 0.877366, 0.870531);
            double n = Sexagesimal(4, 21, 0) / 24.0;
            Assert.AreEqual(0.876125, fn(n), 0.000001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Example 3.e
        [TestMethod]
        public void Example3e()
        {
            var fn = Interpolator.FromN(
                Sexagesimal(0, 54, 36.125),
                Sexagesimal(0, 54, 24.606),
                Sexagesimal(0, 54, 15.486),
                Sexagesimal(0, 54, 8.694),
                Sexagesimal(0, 54, 4.133));

            double n = Sexagesimal(3, 20, 0) / 12.0;
            Assert.AreEqual(Sexagesimal(0, 54, 13.369), fn(n), Sexagesimal(0, 0, 0.1));
        }

        private double Sexagesimal(double h, double m, double s)
        {
            return h + m / 60.0 + s / 3600.0;
        }
    }
}
