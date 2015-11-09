Sorting Algorithms
================================================================================

Various sorting algorithms implemented in C#.

Each algorithm is made as generic as possible, and can sort in both ascending
and descending order.

Each algorithm can be used on any generic collection that implements the 
IEnumerable<T> interface.

Example usage:

    using Algorithms.Sorting;
    
    var x = new[] { 5, 3, 10, 6, 14, 9 };
    var sorted = x.sort(
        x => x, 
        SortingAlgorithm.SelectionSort,
        SortOrder.Ascending);

    // outputs: 3, 5, 6, 9, 10, 14

Run the sorting tests in the console application to see the performance of the
different sorting algorithms.
