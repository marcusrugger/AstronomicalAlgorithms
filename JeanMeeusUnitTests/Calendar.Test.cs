
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class CalendarTests
    {
        [TestMethod]
        public void TestCalendarToDate()
        {
            TestDate(new Calendar(2436116.31), 1957, Months.October, 4.81);
            TestDate(new Calendar(2418781.5), 1910, Months.April, 20.0);
            TestDate(new Calendar(2446470.5), 1986, Months.Febuary, 9.0);
        }

        private void TestDate(Calendar calendar, int expectedYear, int expectedMonth, double expectedDay)
        {
            var date = calendar.Date;

            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day, 0.001);
        }

        [TestMethod]
        public void TestCalendarChangeOverInterval()
        {
            var d1 = Calendar.Create(1582, Months.October, 4.0);
            var d2 = Calendar.Create(1582, Months.October, 15.0);

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
                Calendar.Create(1582, Months.October, 5.0);
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
                Calendar.Create(1582, Months.October, 14.0);
                Assert.Fail("Expected argument out of range exception to occur");
            }

            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void TestCalendarDayOfWeek()
        {
            var date = Calendar.Create(1954, Months.June, 30.0);

            Assert.AreEqual(Weekdays.Wednesday, date.DayOfWeek);
        }
    }
}
