using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class InterpolateThreeTests
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Example 3.a
        [TestMethod]
        public void Example3a()
        {
            var interp = new InterpolateThree(0.884226, 0.877366, 0.870531);
            var n = Convert.Sexagesimal(4, 21, 0) / 24.0;
            var y = interp.FindY(n);
            Assert.AreEqual(0.876125, y, 0.000001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Example 3.b
        [TestMethod]
        public void Example3b()
        {
            var interp = new InterpolateThree(1.3814294, 1.3812213, 1.3812453);

            Assert.AreEqual(1.3812030, interp.ExtremumY, 0.0000001);
            Assert.AreEqual(0.39660, interp.ExtremumN, 0.00001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 26, Example 3.c
        [TestMethod]
        public void Example3c()
        {
            double y1 = -Convert.Sexagesimal(0, 28, 13.4);
            double y2 =  Convert.Sexagesimal(0, 6, 46.3);
            double y3 =  Convert.Sexagesimal(0, 38, 23.2);

            var interp = new InterpolateThree(y1, y2, y3);
            double precision = 0.00001;
            double n = interp.Ybecomes0(precision);

            double expected = -0.20127;
            Assert.AreEqual(expected, n, precision);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 27, Example 3.d
        [TestMethod]
        public void Example3d()
        {
            var interp = new InterpolateThree(-2, 3, 2);
            double precision = 0.000000000001;
            double n = interp.CurvedYbecomes0(precision);

            double expected = -0.720759220056;
            Assert.AreEqual(expected, n, precision);
        }
    }
}
