
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class GregorianCalendarTests
    {
        [TestMethod]
        public void TestToJulianDay()
        {
            /* These test values were obtained from page 62 of Astronomical Algorithms by Jean Meeus */

            TestDate(2451545.0, 2000, 1, 1.5);
            TestDate(2446822.5, 1987, 1, 27.0);
            TestDate(2446966.0, 1987, 6, 19.5);
            TestDate(2447187.5, 1988, 1, 27.0);
            TestDate(2447332.0, 1988, 6, 19.5);
            TestDate(2415020.5, 1900, 1, 1.0);
            TestDate(2305447.5, 1600, 1, 1.0);
            TestDate(2305812.5, 1600, 12, 31.0);
        }

        private void TestDate(double expectedJD, int year, int month, double day)
        {
            double actualJD = GregorianCalendar.ToJulianDay(year, month, day);
            Assert.AreEqual(expectedJD, actualJD, 0.01);
        }

        [TestMethod]
        public void TestFromJulianDay()
        {
            TestDate(2000, 1, 1.5, 2451545.0);
            TestDate(1987, 1, 27.0, 2446822.5);
            TestDate(1987, 6, 19.5, 2446966.0);
            TestDate(1988, 1, 27.0, 2447187.5);
            TestDate(1988, 6, 19.5, 2447332.0);
            TestDate(1900, 1, 1.0, 2415020.5);
            TestDate(1600, 1, 1.0, 2305447.5);
            TestDate(1600, 12, 31.0, 2305812.5);
        }

        private void TestDate(int expectedYear, int expectedMonth, double expectedDay, double JD)
        {
            var date = GregorianCalendar.FromJulianDay(JD);

            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day);
        }

        [TestMethod]
        public void TestGregorianToDate()
        {
            TestDate(GregorianCalendar.Create(2436116.31), 1957, Months.October, 4.81);
            TestDate(GregorianCalendar.Create(2418781.5), 1910, Months.April, 20.0);
            TestDate(GregorianCalendar.Create(2446470.5), 1986, Months.Febuary, 9.0);

            TestDate(GregorianCalendar.Create(2451545.0), 2000, 1, 1.5);
            TestDate(GregorianCalendar.Create(2446822.5), 1987, 1, 27.0);
            TestDate(GregorianCalendar.Create(2446966.0), 1987, 6, 19.5);
            TestDate(GregorianCalendar.Create(2447187.5), 1988, 1, 27.0);
            TestDate(GregorianCalendar.Create(2447332.0), 1988, 6, 19.5);
            TestDate(GregorianCalendar.Create(2415020.5), 1900, 1, 1.0);
            TestDate(GregorianCalendar.Create(2305447.5), 1600, 1, 1.0);
            TestDate(GregorianCalendar.Create(2305812.5), 1600, 12, 31.0);
        }

        private void TestDate(Calendar calendar, int expectedYear, int expectedMonth, double expectedDay)
        {
            var date = calendar.Date;

            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day, 0.001);
        }

        [TestMethod]
        public void TestHalleyInterval()
        {
            var d1 = GregorianCalendar.Create(1910, Months.April, 20.0);
            var d2 = GregorianCalendar.Create(1986, Months.Febuary, 9.0);

            var diff = d2 - d1;

            Assert.AreEqual(27689, diff);
        }
    }
}
