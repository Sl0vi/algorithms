Algorithms
================================================================================

Various algorithms implemented in C#.

- [Sorting algorithms](Sorting)

Binary Search
--------------------------------------------------------------------------------

The binary search algorithm searches for a value in a sorted list. The algorithm
assumes that the list is sorted by the specified key in ascending order.

Usage:

    var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var result = list.BinarySearch(7);

    // result: 7

The algorithm will throw a ValueNotFoundException if the key searched for is not
in the list.

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

