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
            var fn = new InterpolateThree(0.884226, 0.877366, 0.870531);
            var n = Convert.Sexagesimal(4, 21, 0) / 24.0;
            var y = fn.FindY(n);
            Assert.AreEqual(0.876125, y, 0.000001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Example 3.b
        [TestMethod]
        public void Example3b()
        {
            var fn = new InterpolateThree(1.3814294, 1.3812213, 1.3812453);

            Assert.AreEqual(1.3812030, fn.ExtremumY, 0.0000001);
            Assert.AreEqual(0.39660, fn.ExtremumN, 0.00001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 26, Example 3.c
        [TestMethod]
        public void Example3c()
        {
            var fn = new InterpolateThree(
                -Convert.Sexagesimal(0, 28, 13.4),
                Convert.Sexagesimal(0, 6, 46.3),
                Convert.Sexagesimal(0, 38, 23.2));

            Assert.AreEqual(-0.20127, fn.Ybecomes0(0.00001), 0.00001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 27, Example 3.d
        [TestMethod]
        public void Example3d()
        {
            var fn = new InterpolateThree(-2, 3, 2);

            Assert.AreEqual(-0.720759220056, fn.CurvedYbecomes0(0.000000000001), 0.000000000001);
        }
    }
}
