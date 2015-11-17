Algorithms
================================================================================

Various algorithms implemented in C#.

[Sorting algorithms](Sorting/README.md)

Fisher-Yates shuffle or Knuth shuffle
--------------------------------------------------------------------------------

This algorithm takes a collection and shuffles the elements in a random order.
It is implemented as an extension method and can be used on any collection that
implements the IEnumerable<T> interface.

Usage:

    var sorted = new[] { 1, 2, 3, 4, 5, 6 };
    var shuffled = sorted.Shuffle();

    // example output: 
    // 5, 2, 1, 3, 6, 4
