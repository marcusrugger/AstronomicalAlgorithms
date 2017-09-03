
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class JulianDayTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestGregorianDate(2451545.0, 2000, 1, 1.5);
            TestGregorianDate(2446822.5, 1987, 1, 27.0);
            TestGregorianDate(2446966.0, 1987, 6, 19.5);
            TestGregorianDate(2447187.5, 1988, 1, 27.0);
            TestGregorianDate(2447332.0, 1988, 6, 19.5);
            TestGregorianDate(2415020.5, 1900, 1, 1.0);
            TestGregorianDate(2305447.5, 1600, 1, 1.0);
            TestGregorianDate(2305812.5, 1600, 12, 31.0);
        }

        private void TestGregorianDate(double expectedJD, int year, int month, double day)
        {
            double actualJD = JulianDay.GregorianDateToJulianDay(year, month, day);
            Assert.AreEqual(expectedJD, actualJD, 0.01);
        }
    }
}
