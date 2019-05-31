# Chapter 4 - Curve Fitting
The equations found in the classes contained in this folder are described in chapter 4 of [Astronomical Algorithms](https://www.willbell.com/math/mc1.htm) by Jean Meeus.

Each class method should contain a comment with a reference to the page and formula number in the book where the user can find a detailed description of the formula and its use.

Below, in this README, examples are provided that show how to use the classes and methods in code.

### What is curve fitting?
Given a set of points, curve fitting finds the best fitting line or curve to that set of points.

## Class: LinearRegression
File: LinearRegression.cs

### Example 4.b
```csharp
// Given the points in table 4.b
Points[] points = { ... };

var line = new LinearRegression(points);

Assert.AreEqual( -2.49, line.a, 0.01);
Assert.AreEqual(244.18, line.b, 0.01);
Assert.AreEqual(-0.767, line.r, 0.001);
```
