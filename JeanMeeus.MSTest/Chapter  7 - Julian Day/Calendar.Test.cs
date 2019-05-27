using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class CalendarTests
    {
        // Example 7.d, page 64
        [TestMethod]
        public void TestCalendarSubtraction()
        {
            var halley1 = WesternCalendar.Create(1910, Month.April, 20.0);
            var halley2 = WesternCalendar.Create(1986, Month.Febuary, 9.0);

            double days = halley2 - halley1;
            double expected = 27689.0;
            Assert.AreEqual(expected, days);
        }

        // Example 7.d exercise, page 64
        [TestMethod]
        public void TestAddTenThousandDays()
        {
            var startdate = WesternCalendar.Create(1991, Month.July, 11.0);
            var enddate = startdate + 10000.0;
            var date = enddate.Date;

            Assert.AreEqual(2018, date.Year);
            Assert.AreEqual(Month.November, date.Month);
            Assert.AreEqual(26.0, date.Day);
        }
    }
}
