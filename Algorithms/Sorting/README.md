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

Here are some statistics sorting 100.000 random integers on my fairly powerful
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

    Quick sort (parallel):
    Sorted 100000 items, time: 00:00:00.1176755
    Sort Errors: 0

When in doubt, use quick sort.

One interesting observation I made about quick sort (I'm probably not the 
first) is that every time it divides the array, the two recursive calls never
touch the same parts of the array. It should therefore be completely safe to
run them in parallel.

Unfortunately, parallellization isn't completely free in C#, so on small 
collections the non-parallel version still beats the parallel one, but on larger
collections, especially if you have many cores in your computer, the parallel
version is faster.

More statistics from my computer:

    Quick sort:
    Sorted 10000 items, time: 00:00:00.0178172
    Sort Errors: 0

    Quick sort (parallel):
    Sorted 10000 items, time: 00:00:00.0367258
    Sort Errors: 0

    Quick sort:
    Sorted 100000 items, time: 00:00:00.1572899
    Sort Errors: 0

    Quick sort (parallel):
    Sorted 100000 items, time: 00:00:00.1337186
    Sort Errors: 0

    Quick sort:
    Sorted 1000000 items, time: 00:00:01.8010622
    Sort Errors: 0

    Quick sort (parallel):
    Sorted 1000000 items, time: 00:00:00.8060380
    Sort Errors: 0

    Quick sort:
    Sorted 10000000 items, time: 00:00:20.2252177
    Sort Errors: 0

    Quick sort (parallel):
    Sorted 10000000 items, time: 00:00:08.8387155
    Sort Errors: 0

Less than 1 million million numbers and the difference is barely noticable, but
at 10 million the difference is huge.
