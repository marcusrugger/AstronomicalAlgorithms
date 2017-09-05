
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class GregorianCalendarTests
    {
        [TestMethod]
        public void TestGregorianToDate()
        {
            TestGregorianDate(new GregorianCalendar(2436116.31), 1957, Months.October, 4.81);
            TestGregorianDate(new GregorianCalendar(2418781.5), 1910, Months.April, 20.0);
            TestGregorianDate(new GregorianCalendar(2446470.5), 1986, Months.Febuary, 9.0);

            TestGregorianDate(new GregorianCalendar(2451545.0), 2000, 1, 1.5);
            TestGregorianDate(new GregorianCalendar(2446822.5), 1987, 1, 27.0);
            TestGregorianDate(new GregorianCalendar(2446966.0), 1987, 6, 19.5);
            TestGregorianDate(new GregorianCalendar(2447187.5), 1988, 1, 27.0);
            TestGregorianDate(new GregorianCalendar(2447332.0), 1988, 6, 19.5);
            TestGregorianDate(new GregorianCalendar(2415020.5), 1900, 1, 1.0);
            TestGregorianDate(new GregorianCalendar(2305447.5), 1600, 1, 1.0);
            TestGregorianDate(new GregorianCalendar(2305812.5), 1600, 12, 31.0);
        }

        private void TestGregorianDate(Calendar calendar, int expectedYear, int expectedMonth, double expectedDay)
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
