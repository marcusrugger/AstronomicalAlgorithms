using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class WeekdayMethodsTests
    {
        [TestMethod]
        public void TestFromIndex()
        {
            Assert.AreEqual(Weekday.Sunday, WeekdayMethods.FromIndex(0));
            Assert.AreEqual(Weekday.Monday, WeekdayMethods.FromIndex(1));
            Assert.AreEqual(Weekday.Tuesday, WeekdayMethods.FromIndex(2));
            Assert.AreEqual(Weekday.Wednesday, WeekdayMethods.FromIndex(3));
            Assert.AreEqual(Weekday.Thursday, WeekdayMethods.FromIndex(4));
            Assert.AreEqual(Weekday.Friday, WeekdayMethods.FromIndex(5));
            Assert.AreEqual(Weekday.Saturday, WeekdayMethods.FromIndex(6));
        }

        [TestMethod]
        public void TestFromIndexOutOfRangeUnder()
        {
            try
            {
                WeekdayMethods.FromIndex(-1);
                Assert.Fail("WeekdaysMethods.FromIndex should have thrown execption");
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        [TestMethod]
        public void TestFromIndexOutOfRangeOver()
        {
            try
            {
                WeekdayMethods.FromIndex(7);
                Assert.Fail("WeekdaysMethods.FromIndex should have thrown execption");
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        [TestMethod]
        public void TestToIndex()
        {
            Assert.AreEqual(0, WeekdayMethods.ToIndex(Weekday.Sunday));
            Assert.AreEqual(1, WeekdayMethods.ToIndex(Weekday.Monday));
            Assert.AreEqual(2, WeekdayMethods.ToIndex(Weekday.Tuesday));
            Assert.AreEqual(3, WeekdayMethods.ToIndex(Weekday.Wednesday));
            Assert.AreEqual(4, WeekdayMethods.ToIndex(Weekday.Thursday));
            Assert.AreEqual(5, WeekdayMethods.ToIndex(Weekday.Friday));
            Assert.AreEqual(6, WeekdayMethods.ToIndex(Weekday.Saturday));
        }

        [TestMethod]
        public void TestToIndexOutOfRange()
        {
            try
            {
                WeekdayMethods.ToIndex(Weekday.Weekday);
                Assert.Fail("WeekdaysMethods.ToIndex should have thrown execption");
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(Weekday.Monday, WeekdayMethods.Add(Weekday.Friday, 3));
            Assert.AreEqual(Weekday.Friday, WeekdayMethods.Add(Weekday.Monday, -3));

            Assert.AreEqual(Weekday.Monday, WeekdayMethods.Add(Weekday.Monday, 14));
            Assert.AreEqual(Weekday.Monday, WeekdayMethods.Add(Weekday.Monday, -14));
        }

        // Example 7.e, page 65
        [TestMethod]
        public void TestFromJulianDay()
        {
            var calendar = WesternCalendar.Create(1954, Month.June, 30);
            var weekday = WeekdayMethods.From(calendar);
            Assert.AreEqual(Weekday.Wednesday, weekday);
        }
    }
}
