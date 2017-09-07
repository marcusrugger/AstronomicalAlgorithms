
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeanMeeus;

namespace JeanMeeusUnitTests
{
    [TestClass]
    public class WeekdaysMethodsTests
    {
        [TestMethod]
        public void TestFromIndex()
        {
            Assert.AreEqual(Weekdays.Sunday, WeekdaysMethods.FromIndex(0));
            Assert.AreEqual(Weekdays.Monday, WeekdaysMethods.FromIndex(1));
            Assert.AreEqual(Weekdays.Tuesday, WeekdaysMethods.FromIndex(2));
            Assert.AreEqual(Weekdays.Wednesday, WeekdaysMethods.FromIndex(3));
            Assert.AreEqual(Weekdays.Thursday, WeekdaysMethods.FromIndex(4));
            Assert.AreEqual(Weekdays.Friday, WeekdaysMethods.FromIndex(5));
            Assert.AreEqual(Weekdays.Saturday, WeekdaysMethods.FromIndex(6));
        }

        [TestMethod]
        public void TestFromIndexOutOfRangeUnder()
        {
            try
            {
                WeekdaysMethods.FromIndex(-1);
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
                WeekdaysMethods.FromIndex(7);
                Assert.Fail("WeekdaysMethods.FromIndex should have thrown execption");
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        [TestMethod]
        public void TestToIndex()
        {
            Assert.AreEqual(0, WeekdaysMethods.ToIndex(Weekdays.Sunday));
            Assert.AreEqual(1, WeekdaysMethods.ToIndex(Weekdays.Monday));
            Assert.AreEqual(2, WeekdaysMethods.ToIndex(Weekdays.Tuesday));
            Assert.AreEqual(3, WeekdaysMethods.ToIndex(Weekdays.Wednesday));
            Assert.AreEqual(4, WeekdaysMethods.ToIndex(Weekdays.Thursday));
            Assert.AreEqual(5, WeekdaysMethods.ToIndex(Weekdays.Friday));
            Assert.AreEqual(6, WeekdaysMethods.ToIndex(Weekdays.Saturday));
        }

        [TestMethod]
        public void TestToIndexOutOfRange()
        {
            try
            {
                WeekdaysMethods.ToIndex(Weekdays.Weekday);
                Assert.Fail("WeekdaysMethods.ToIndex should have thrown execption");
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(Weekdays.Monday, WeekdaysMethods.Add(Weekdays.Friday, 3));
            Assert.AreEqual(Weekdays.Friday, WeekdaysMethods.Add(Weekdays.Monday, -3));

            Assert.AreEqual(Weekdays.Monday, WeekdaysMethods.Add(Weekdays.Monday, 14));
            Assert.AreEqual(Weekdays.Monday, WeekdaysMethods.Add(Weekdays.Monday, -14));
        }
    }
}
