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
            Assert.AreEqual(0, Weekday.Sunday.ToIndex());
            Assert.AreEqual(1, Weekday.Monday.ToIndex());
            Assert.AreEqual(2, Weekday.Tuesday.ToIndex());
            Assert.AreEqual(3, Weekday.Wednesday.ToIndex());
            Assert.AreEqual(4, Weekday.Thursday.ToIndex());
            Assert.AreEqual(5, Weekday.Friday.ToIndex());
            Assert.AreEqual(6, Weekday.Saturday.ToIndex());
        }

        [TestMethod]
        public void TestToIndexOutOfRange()
        {
            try
            {
                Weekday.Weekday.ToIndex();
                Assert.Fail("WeekdaysMethods.ToIndex should have thrown execption");
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(Weekday.Monday, Weekday.Friday.Add(3));
            Assert.AreEqual(Weekday.Friday, Weekday.Monday.Add(-3));

            Assert.AreEqual(Weekday.Monday, Weekday.Monday.Add(14));
            Assert.AreEqual(Weekday.Monday, Weekday.Monday.Add(-14));

            Assert.AreEqual(Weekday.Sunday, Weekday.Sunday.Add(21));
            Assert.AreEqual(Weekday.Monday, Weekday.Sunday.Add(22));
            Assert.AreEqual(Weekday.Tuesday, Weekday.Sunday.Add(23));
            Assert.AreEqual(Weekday.Wednesday, Weekday.Sunday.Add(24));
            Assert.AreEqual(Weekday.Thursday, Weekday.Sunday.Add(25));
            Assert.AreEqual(Weekday.Friday, Weekday.Sunday.Add(26));
            Assert.AreEqual(Weekday.Saturday, Weekday.Sunday.Add(27));

            Assert.AreEqual(Weekday.Sunday, Weekday.Monday.Add(20));
            Assert.AreEqual(Weekday.Monday, Weekday.Monday.Add(21));
            Assert.AreEqual(Weekday.Tuesday, Weekday.Monday.Add(22));
            Assert.AreEqual(Weekday.Wednesday, Weekday.Monday.Add(23));
            Assert.AreEqual(Weekday.Thursday, Weekday.Monday.Add(24));
            Assert.AreEqual(Weekday.Friday, Weekday.Monday.Add(25));
            Assert.AreEqual(Weekday.Saturday, Weekday.Monday.Add(26));
        }

        // Example 7.e, page 65
        [TestMethod]
        public void TestFromJulianDay()
        {
            var calendar = WesternCalendar.Create(1954, Month.June, 30);
            var weekday = WeekdayMethods.From(calendar);
            Assert.AreEqual(Weekday.Wednesday, weekday);
        }

        [TestMethod]
        public void TestIsWeekday()
        {
            Assert.IsTrue(Weekday.Monday.IsWeekday());
            Assert.IsTrue(Weekday.Tuesday.IsWeekday());
            Assert.IsTrue(Weekday.Wednesday.IsWeekday());
            Assert.IsTrue(Weekday.Thursday.IsWeekday());
            Assert.IsTrue(Weekday.Friday.IsWeekday());

            Assert.IsFalse(Weekday.Saturday.IsWeekday());
            Assert.IsFalse(Weekday.Sunday.IsWeekday());
        }

        [TestMethod]
        public void TestIsWeekend()
        {
            Assert.IsFalse(Weekday.Monday.IsWeekend());
            Assert.IsFalse(Weekday.Tuesday.IsWeekend());
            Assert.IsFalse(Weekday.Wednesday.IsWeekend());
            Assert.IsFalse(Weekday.Thursday.IsWeekend());
            Assert.IsFalse(Weekday.Friday.IsWeekend());

            Assert.IsTrue(Weekday.Saturday.IsWeekend());
            Assert.IsTrue(Weekday.Sunday.IsWeekend());
        }
    }
}
