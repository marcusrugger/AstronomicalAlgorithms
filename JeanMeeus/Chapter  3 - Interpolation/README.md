# Chapter 3 - Interpolation
The equations found in the classes contained in this folder are described in chapter 3 of [Astronomical Algorithms](https://www.willbell.com/math/mc1.htm) by Jean Meeus.

Each class method should contain a comment with a reference to the page and formula number in the book where the user can find a detailed description of the formula and its use.

Below, in this README, examples are provided that show how to use the classes and methods in code.

### What is interpolation?
According to [Wikipedia](https://en.wikipedia.org/wiki/Interpolation), **interpolation** is: _"a method of constructing new data points within the range of a discrete set of known data points."_

Meeus describes interpolation as, _"the process of finding values for instants, quantities, etc., intermediate to those given in a table."_

## Class Interpolate
File: Interpolate.cs

```csharp
var fn = Interpolate.FromN(y1, y2, y3);
var y = fn(n);
```
