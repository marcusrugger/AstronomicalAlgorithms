﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class InterpolateTests
    {
        private double Sexagesimal(double h, double m, double s)
        {
            return Convert.Sexagecimal(h, m, s);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Example 3.a
        [TestMethod]
        public void Example3a()
        {
            var n = Sexagesimal(4, 21, 0) / 24.0;
            var y = Interpolate.FromN(0.884226, 0.877366, 0.870531)(n);
            Assert.AreEqual(0.876125, y, 0.000001);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Example 3.e
        [TestMethod]
        public void Example3e()
        {
            var fn = Interpolate.FromN(
                Sexagesimal(0, 54, 36.125),
                Sexagesimal(0, 54, 24.606),
                Sexagesimal(0, 54, 15.486),
                Sexagesimal(0, 54, 8.694),
                Sexagesimal(0, 54, 4.133));

            var n = Sexagesimal(3, 20, 0) / 12.0;
            var y = fn(n);
            Assert.AreEqual(Sexagesimal(0, 54, 13.369), y, Sexagesimal(0, 0, 0.1));
        }
    }
}
