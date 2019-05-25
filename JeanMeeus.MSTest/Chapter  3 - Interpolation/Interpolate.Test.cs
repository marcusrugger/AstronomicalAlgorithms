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
            var n = Convert.Sexagesimal(4, 21, 0) / 24.0;
            var y = Interpolate.Given(0.884226, 0.877366, 0.870531)(n);
            Assert.AreEqual(0.876125, y, 0.000001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Example 3.e
        [TestMethod]
        public void Example3e()
        {
            double y1 = Convert.Sexagesimal(0, 54, 36.125);
            double y2 = Convert.Sexagesimal(0, 54, 24.606);
            double y3 = Convert.Sexagesimal(0, 54, 15.486);
            double y4 = Convert.Sexagesimal(0, 54, 8.694);
            double y5 = Convert.Sexagesimal(0, 54, 4.133);

            var fn = Interpolate.Given(y1, y2, y3, y4, y5);
            var n = Convert.Sexagesimal(3, 20, 0) / 12.0;
            var y = fn(n);

            var expected = Convert.Sexagesimal(0, 54, 13.369);
            var precision = Convert.Sexagesimal(0, 0, 0.001);
            Assert.AreEqual(expected, y, precision);
        }

        // n = -1, should result in fn(n) == y1
        // n =  0, should result in fn(n) == y2
        // n =  1, should result in fn(n) == y3
        [TestMethod]
        public void TestRangeThree()
        {
            double y1 = 0.884226;
            double y2 = 0.877366;
            double y3 = 0.870531;
            var fn = Interpolate.Given(y1, y2, y3);

            Assert.AreEqual(y1, fn(-1.0), 0.000001);
            Assert.AreEqual(y2, fn(0.0), 0.000001);
            Assert.AreEqual(y3, fn(1.0), 0.000001);
        }

        // n = -1, should result in fn(n) == y2
        // n =  0, should result in fn(n) == y3
        // n =  1, should result in fn(n) == y4
        [TestMethod]
        public void TestRangeFive()
        {
            double y1 = Convert.Sexagesimal(0, 54, 36.125);
            double y2 = Convert.Sexagesimal(0, 54, 24.606);
            double y3 = Convert.Sexagesimal(0, 54, 15.486);
            double y4 = Convert.Sexagesimal(0, 54, 8.694);
            double y5 = Convert.Sexagesimal(0, 54, 4.133);
            var fn = Interpolate.Given(y1, y2, y3, y4, y5);

            double precision = Convert.Sexagesimal(0, 0, 0.001);
            Assert.AreEqual(y2, fn(-1.0), precision);
            Assert.AreEqual(y3, fn(0.0), precision);
            Assert.AreEqual(y4, fn(1.0), precision);
        }
    }
}
