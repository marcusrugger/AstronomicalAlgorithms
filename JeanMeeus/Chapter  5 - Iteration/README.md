# Chapter 5 - Iteration
The equations found in the classes contained in this folder are described in chapter 5 of [Astronomical Algorithms](https://www.willbell.com/math/mc1.htm) by Jean Meeus.

Each class method should contain a comment with a reference to the page and formula number in the book where the user can find a detailed description of the formula and its use.

Below, in this README, examples are provided that show how to use the classes and methods in code.

### What is iteration?
Meeus describes iteration as, "a method consisting of repeating a calculation several times, until the value of an unknown quantity is obtained."

## Class: Iteration
File: Iteration.cs

`Iteration` is a class with a single static public method which takes the starting values of the iteration, a precision value, and returns a function that can be called with a lambda containing the equation to solve.

### Example 5.a
Given the following equation:

```x^5 + 17x - 8 = 0```

Find 'x' using the binary search algorithm described on page 53.
```csharp
const double PRECISION = 0.000000001;

var biterator = Iteration.Create(0, 1, PRECISION);
var result = biterator((x) => Math.Pow(x, 5) + 17 * x - 8);

double expected = 0.469249878;
Assert.AreEqual(expected, result, PRECISION);
```
