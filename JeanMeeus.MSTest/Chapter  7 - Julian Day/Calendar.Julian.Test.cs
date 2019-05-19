using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class JulianCalendarTests
    {
        [TestMethod]
        public void TestJulianToDate()
        {
            TestDate(JulianCalendar.Create(1842713.0), 333, Month.January, 27.5);

            TestDate(JulianCalendar.Create(2026871.8), 837, 4, 10.3);
            TestDate(JulianCalendar.Create(1356001.0), -1000, 7, 12.5);
            TestDate(JulianCalendar.Create(1355866.5), -1000, 2, 29.0);
            TestDate(JulianCalendar.Create(1355671.4), -1001, 8, 17.9);
            TestDate(JulianCalendar.Create(0.0), -4712, 1, 1.5);
        }

        private void TestDate(Calendar calendar, int expectedYear, int expectedMonth, double expectedDay)
        {
            var date = calendar.Date;

            Assert.AreEqual(expectedYear, date.Year);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(expectedDay, date.Day, 0.001);
        }
    }
}
