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

    // sorted: 3, 5, 6, 9, 10, 14

The algorithms can even sort more complex objects as long as you specify a
sorting key that implements the IComparable interface.

    using Algorithms.Sorting;

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    var x = new[]
    {
        new Customer { Id = 1, Name = "John" },
        new Customer { Id = 3, Name = "George" },
        new Customer { Id = 2, Name = "Lucas" }
    };

    var sorted = x.Sort(
        x => x.Id,
        SortingAlgorithm.QuickSort,
        SortOrder.Descending);

    // sorted:
    // { Id: 3, Name: "George" },
    // { Id: 2, Name: "Lucas" },
    // { Id: 1, Name: "John" }

You can also use the string property as the sorting key:

    var sorted2 = x.Sort(
        x => x.Name,
        SortingAlgorithm.InsertionSort); // Defaults to ascending order

    // sorted2:
    // { Id: 3, Name: "George" },
    // { Id: 1, Name: "John" },
    // { Id: 2, Name: "Lucas" }

Run the sorting tests in the console application to see the performance of the
different sorting algorithms.

Here are some stats sorting 100.000 random integers on my fairly powerful
computer, running Mono 4.0.4 on Linux Mint 17.2

    Selection sort:
    Sorted 100000 items, time: 00:03:06.5617469
    Sort Errors: 0

    Insertion sort:
    Sorted 100000 items, time: 00:01:12.5025853
    Sort Errors: 0

    Bubble sort:
    Sorted 100000 items, time: 00:05:55.9111441
    Sort Errors: 0

    Bubble sort (optimized):
    Sorted 100000 items, time: 00:02:56.3421492
    Sort Errors: 0

    Quick sort:
    Sorted 100000 items, time: 00:00:00.0659589
    Sort Errors: 0

When in doubt, use quick sort.
