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

        // Astronomical Algorithms by Jean Meeus, Chapter 4, page 40, Example 4.b
        [TestMethod]
        public void Example4b()
        {
            Point[] points =
            {
                // Left column
                new Point { x = 73, y =  90.4 },
                new Point { x = 38, y = 125.3 },
                new Point { x = 35, y = 161.8 },
                new Point { x = 42, y = 143.4 },
                new Point { x = 78, y =  52.5 },
                new Point { x = 68, y =  50.8 },
                new Point { x = 74, y =  71.5 },
                new Point { x = 42, y = 152.8 },
                new Point { x = 52, y = 131.3 },
                new Point { x = 54, y =  98.5 },
                new Point { x = 39, y = 144.8 },

                // Right column
                new Point { x = 61, y =  78.1 },
                new Point { x = 42, y =  89.5 },
                new Point { x = 49, y =  63.9 },
                new Point { x = 50, y = 112.1 },
                new Point { x = 62, y =  82.0 },
                new Point { x = 44, y = 119.8 },
                new Point { x = 39, y = 161.2 },
                new Point { x = 43, y = 208.4 },
                new Point { x = 54, y = 111.6 },
                new Point { x = 44, y = 167.1 },
                new Point { x = 37, y = 162.1 }
            };

            var line = new LinearRegression(points);

            Assert.AreEqual( -2.49, line.a, 0.01);
            Assert.AreEqual(244.18, line.b, 0.01);
            Assert.AreEqual(-0.767, line.r, 0.001);
        }
    }
}
