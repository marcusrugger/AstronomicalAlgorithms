using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class DateTests
    {
        [TestMethod]
        public void TestDateTimeTypecasts()
        {
            int year = 2019;
            int month = Month.May;
            double day = 25 + Convert.Sexagesimal(1, 23, 45.678) / 24;
            double precision = Convert.Sexagesimal(0, 0, 0.001);

            var original = new Date(year, month, day);

            DateTime dt = original;
            Assert.AreEqual(year, dt.Year);
            Assert.AreEqual(month, dt.Month);
            Assert.AreEqual(25, dt.Day);
            Assert.AreEqual(1, dt.Hour);
            Assert.AreEqual(23, dt.Minute);
            Assert.AreEqual(45, dt.Second);
            Assert.AreEqual(678, dt.Millisecond);

            Date date = dt;
            Assert.AreEqual(original.Year, date.Year);
            Assert.AreEqual(original.Month, date.Month);
            Assert.AreEqual(original.Day, date.Day, precision);
        }
    }
}
