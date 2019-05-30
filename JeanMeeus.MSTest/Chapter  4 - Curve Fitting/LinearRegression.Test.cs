using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeanMeeus.MSTest
{
    [TestClass]
    public class LinearRegressionTests
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 4, page 37, Example 4.a
        [TestMethod]
        public void Example4a()
        {
            Point[] points =
            {
                // February
                new Point { x = 0.2982, y = 10.92 },
                new Point { x = 0.2969, y = 11.01 },
                new Point { x = 0.2918, y = 10.99 },
                new Point { x = 0.2905, y = 10.78 },
                new Point { x = 0.2707, y = 10.87 },

                // March
                new Point { x = 0.2574, y = 10.80 },
                new Point { x = 0.2485, y = 10.75 },
                new Point { x = 0.2287, y = 10.14 },

                // April
                new Point { x = 0.2238, y = 10.21 },
                new Point { x = 0.2156, y =  9.97 },
                new Point { x = 0.1992, y =  9.69 },

                // May
                new Point { x = 0.1948, y =  9.57 },
                new Point { x = 0.1931, y =  9.66 },
                new Point { x = 0.1889, y =  9.63 },
                new Point { x = 0.1781, y =  9.65 },
                new Point { x = 0.1772, y =  9.44 },
                new Point { x = 0.1770, y =  9.44 },

                // June
                new Point { x = 0.1755, y =  9.32 },
                new Point { x = 0.1746, y =  9.20 }
            };

            var line = new LinearRegression(points);

            Assert.AreEqual(13.67, line.a, 0.01);
            Assert.AreEqual( 7.03, line.b, 0.01);
        }
    }
}
