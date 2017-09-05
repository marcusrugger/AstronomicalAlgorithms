
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class JulianCalendarTests
    {
        [TestMethod]
        public void TestJulianToDate()
        {
            TestJulianDate(new JulianCalendar(1842713.0), 333, Months.January, 27.5);
        }

        private void TestJulianDate(Calendar calendar, int expectedYear, int expectedMonth, double expectedDay)
        {
            var date = calendar.Date;

            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day, 0.001);
        }
    }
}
