# Chapter 3 - Interpolation
The equations found in the classes contained in this folder are described in chapter 3 of [Astronomical Algorithms](https://www.willbell.com/math/mc1.htm) by Jean Meeus.

Each class method should contain a comment with a reference to the page and formula number in the book where the user can find a detailed description of the formula and its use.

Below, in this README, examples are provided that show how to use the classes and methods in code.

### What is interpolation?
According to [Wikipedia](https://en.wikipedia.org/wiki/Interpolation), **interpolation** is: _"a method of constructing new data points within the range of a discrete set of known data points."_

Meeus describes interpolation as, _"the process of finding values for instants, quantities, etc., intermediate to those given in a table."_

Meeus drives home the point of what the formula in this chapter are for: calculating values intermediate to those given in a table.

## Class Interpolate
File: Interpolate.cs

`Interpolate` is a static class with only two static methods.  One for interpolating from 3-points and another for interpolating from 5.  As the methods are static, the may be called directly.

```csharp
// Where y1, y2, and y2 are obtained from the table of interest.
// and where n is n = x - x2, where x is the intermediate x of interest.
var fn = Interpolate.FromN(y1, y2, y3);
var y = fn(n);

// Or, if you are calculating only a single value, you may use:
var y = Interpolate.FromN(y1, y2, y3)(n);
```
### Example 3.a
Consider the example Meeus gives for the distance to Mars from Earth in November 1992.

Calculate the distance to Mars on November 8, at 4:21 AM (all times TD).  This example is also a unit test.

Date | Distance (AU)
--- | ---
7 | 0.884 226
8 | 0.877 366
9 | 0.870 531

```csharp
var fn = Interpolate.FromN(0.884226, 0.877366, 0.870531);
var n = Convert.Sexagecimal(4, 21, 0) / 24;
var y = fn(n);
Console.WriteLine($"y = {y}");
```
