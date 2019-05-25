using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class WesternCalendarTests
    {
        [TestMethod]
        public void TestCalendarToDate()
        {
            TestDate(WesternCalendar.Create(2436116.31), 1957, Month.October, 4.81);
            TestDate(WesternCalendar.Create(2418781.5), 1910, Month.April, 20.0);
            TestDate(WesternCalendar.Create(2446470.5), 1986, Month.Febuary, 9.0);

            TestDate(WesternCalendar.Create(2451545.0), 2000, 1, 1.5);
            TestDate(WesternCalendar.Create(2446822.5), 1987, 1, 27.0);
            TestDate(WesternCalendar.Create(2446966.0), 1987, 6, 19.5);
            TestDate(WesternCalendar.Create(2447187.5), 1988, 1, 27.0);
            TestDate(WesternCalendar.Create(2447332.0), 1988, 6, 19.5);
            TestDate(WesternCalendar.Create(2415020.5), 1900, 1, 1.0);
            TestDate(WesternCalendar.Create(2305447.5), 1600, 1, 1.0);
            TestDate(WesternCalendar.Create(2305812.5), 1600, 12, 31.0);

            TestDate(WesternCalendar.Create(2026871.8), 837, 4, 10.3);
            TestDate(WesternCalendar.Create(1356001.0), -1000, 7, 12.5);
            TestDate(WesternCalendar.Create(1355866.5), -1000, 2, 29.0);
            TestDate(WesternCalendar.Create(1355671.4), -1001, 8, 17.9);
            TestDate(WesternCalendar.Create(0.0), -4712, 1, 1.5);
        }

        private void TestDate(Calendar calendar, int expectedYear, int expectedMonth, double expectedDay)
        {
            TestDate(calendar.Date, expectedYear, expectedMonth, expectedDay);
        }

        private void TestDate(Date date, int expectedYear, int expectedMonth, double expectedDay)
        {
            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day, 0.001);
        }

        [TestMethod]
        public void TestCalendarChangeOverInterval()
        {
            var d1 = WesternCalendar.Create(1582, Month.October, 4.0);
            var d2 = WesternCalendar.Create(1582, Month.October, 15.0);

            var diff = d2 - d1;
            Assert.AreEqual(1.0, diff);

            Assert.AreEqual(2299159.5, d1.JulianDay);
            Assert.AreEqual(2299160.5, d2.JulianDay);
        }

        [TestMethod]
        public void TestCalendarChangeOver_15821005()
        {
            try
            {
                WesternCalendar.Create(1582, Month.October, 5.0);
                Assert.Fail("Expected argument out of range exception to occur");
            }

            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void TestCalendarChangeOver_15821014()
        {
            try
            {
                WesternCalendar.Create(1582, Month.October, 14.0);
                Assert.Fail("Expected argument out of range exception to occur");
            }

            catch (ArgumentOutOfRangeException)
            {
            }
        }

        // Example 7.c on page 64, including exercise
        [TestMethod]
        public void TestFromJulianDay()
        {
            Date date;

            date = WesternCalendar.FromJulianDay(2436116.31);
            TestDate(date, 1957, Month.October, 4.81);

            date = WesternCalendar.FromJulianDay(1842713.0);
            TestDate(date, 333, Month.January, 27.5);

            date = WesternCalendar.FromJulianDay(1507900.13);
            TestDate(date, -584, Month.May, 28.63);
        }
    }
}
