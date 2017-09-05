﻿
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

            TestJulianDate(new JulianCalendar(2026871.8), 837, 4, 10.3);
            TestJulianDate(new JulianCalendar(1356001.0), -1000, 7, 12.5);
            TestJulianDate(new JulianCalendar(1355866.5), -1000, 2, 29.0);
            TestJulianDate(new JulianCalendar(1355671.4), -1001, 8, 17.9);
            TestJulianDate(new JulianCalendar(0.0), -4712, 1, 1.5);
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
