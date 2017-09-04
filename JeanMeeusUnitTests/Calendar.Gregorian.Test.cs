
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
            TestGregorianDate(new GregorianCalendar(2436116.31), 1957, 10, 4.81);
        }

        private void TestGregorianDate(GregorianCalendar calendar, int expectedYear, int expectedMonth, double expectedDay)
        {
            var date = calendar.Date;

            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day, 0.001);
        }
    }
}
