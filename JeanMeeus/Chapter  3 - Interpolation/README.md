# Chapter 3 - Interpolation
The equations found in the classes contained in this folder are described in chapter 3 of [Astronomical Algorithms](https://www.willbell.com/math/mc1.htm) by Jean Meeus.

Each class method should contain a comment with a reference to the page and formula number in the book where the user can find a detailed description of the formula and its use.

Below, in this README, examples are provided that show how to use the classes and methods in code.

### What is interpolation?
According to [Wikipedia](https://en.wikipedia.org/wiki/Interpolation), **interpolation** is: _"a method of constructing new data points within the range of a discrete set of known data points."_

Meeus describes interpolation as, _"the process of finding values for instants, quantities, etc., intermediate to those given in a table."_

Meeus drives home the point of what the formula in this chapter are for: calculating values intermediate to those given in a table.

## Class: Interpolate
File: Interpolate.cs

`Interpolate` is a static class with only two static methods.  One for interpolating from 3-points and another for interpolating from 5.  As the methods are static, the may be called directly.

```csharp
// Where y1, y2, and y2 are obtained from the table of interest.
// and where n is typically -1.0 <= n <= 1.0, where:
//   -1 corresponds to y1
//    0 corresponds to y2
//    1 corresponds to y3
var fn = Interpolate.FromN(y1, y2, y3);
var y = fn(n);

// Or, if you are calculating only a single value, you may use:
var y = Interpolate.FromN(y1, y2, y3)(n);
```
### Example 3.a
Consider the example Meeus gives for the distance to Mars from Earth in November 1992.

Calculate the distance to Mars on November 8, at 4:21 TD.  This example is also a unit test.

Date | Distance (AU)
--- | ---
7 | 0.884 226
8 | 0.877 366
9 | 0.870 531

```csharp
var fn = Interpolate.FromN(0.884226, 0.877366, 0.870531);
var n = Convert.Sexagesimal(4, 21, 0) / 24;
var y = fn(n);
Console.WriteLine($"y = {y}");
```
### Example 3.e
In this example, Meeus interpolates, from 5 values, the lunar parallax on February 28, 1992 at 3:20 TD.

Date | Parallax
--- | ---
27.0 | 0&deg; 54' 36.125"
27.5 | 0&deg; 54' 24.606"
28.0 | 0&deg; 54' 15.486"
28.5 | 0&deg; 54' 8.694"
29.0 | 0&deg; 54' 4.133"

```csharp
double y1 = Convert.Sexagesimal(0, 54, 36.125);
double y2 = Convert.Sexagesimal(0, 54, 24.606);
double y3 = Convert.Sexagesimal(0, 54, 15.486);
double y4 = Convert.Sexagesimal(0, 54, 8.694);
double y5 = Convert.Sexagesimal(0, 54, 4.133);

var fn = Interpolate.FromN(y1, y2, y3, y4, y5);
var n = Convert.Sexagesimal(3, 20, 0) / 12;
var y = fn(n);

Console.WriteLine($"y = {y}");
```
## Class: InterpolateThree
File: Interpolate.Three.cs

In chapter 3, Meeus provides various algorithms for interpolating from three values.  Such as finding the extremum or calculating when y becomes 0.  This class implements those algorithms.
### Example 3.b
In this example, Meeus calculates the passage of Mars through perihelion in May 1992.

Date | Distance (AU)
--- | ---
12.0 | 1.381 4294
16.0 | 1.381 2213
20.0 | 1.381 2453
```csharp
double x2 = 16.0;

double y1 = 1.3814294;
double y2 = 1.3812213;
double y3 = 1.3812453;

var interp = new InterpolateThree(y1, y2, y3);
var n = interp.ExtremumN;  // Value of n at perihelion
var x = x2 + 4 * n;        // Time of perihelion.  Multiply n by 4, the table interval
var y = interp.ExtremumY;  // Distance from sun at perihelion
```
### Example 3.c
For February of 1973, calculate when the planet Mercury's declination reaches 0.

Date | Declination
--- | ---
26.0 | -0&deg; 28' 13.4"
27.0 | +0&deg; 6' 46.3"
28.0 | +0&deg; 38' 23.2"

```csharp
double x2 = 27.0;

double y1 = -Convert.Sexagesimal(0, 28, 13.4);
double y2 =  Convert.Sexagesimal(0, 6, 46.3);
double y3 =  Convert.Sexagesimal(0, 38, 23.2);

var interp = new InterpolateThree(y1, y2, y3);
var precision = Convert.Sexagesimal(0, 0, 0.1);
var n = interp.Ybecomes0(precision);
var x = x2 + n;
```
