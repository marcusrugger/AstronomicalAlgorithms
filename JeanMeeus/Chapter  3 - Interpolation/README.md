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
