using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class InterpolateTests
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Example 3.a
        [TestMethod]
        public void Example3a()
        {
            var fn = Interpolate.From(8.0, 0.884226, 0.877366, 0.870531);
            Assert.AreEqual(0.876125, fn(8.18125), 0.000001);
        }
    }
}
