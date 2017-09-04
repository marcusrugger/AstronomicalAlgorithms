
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class GregorianCalendarTests
    {
        [TestMethod]
        public void TestToDate()
        {
            TestGregorianDate(new GregorianCalendar(2436116.31), 1957, Date.October, 4.81);
            TestGregorianDate(new GregorianCalendar(2418781.5), 1910, Date.April, 20.0);
            TestGregorianDate(new GregorianCalendar(2446470.5), 1986, Date.Febuary, 9.0);
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
            var d1 = GregorianCalendar.Create(1910, Date.April, 20.0);
            var d2 = GregorianCalendar.Create(1986, Date.Febuary, 9.0);

            var diff = d2.JulianDay - d1.JulianDay;

            Assert.AreEqual(27689, diff);
        }
    }
}
