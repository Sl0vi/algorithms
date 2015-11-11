using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Algorithms.Sorting;

namespace Algorithms.ConsoleTests
{
    static class MainClass
    {
        static Random random = new Random();

        public static void Main(string[] args)
        {
            SortingTests();

            Console.WriteLine("Done, press any key to exit");
            Console.ReadKey(true);
        }

        static void SortingTests()
        {
            var warmup = new[] { 30, 2, 18, 20, 5, 36, 19 };

            warmup.Sort(x => x, SortingAlgorithm.SelectionSort);
            warmup.Sort(x => x, SortingAlgorithm.InsertionSort);
            warmup.Sort(x => x, SortingAlgorithm.BubbleSort);
            warmup.Sort(x => x, SortingAlgorithm.BubbleSortOptimized);
            warmup.Sort(x => x, SortingAlgorithm.QuickSort);

            var bigCollection = new int[100000];
            for (var i = 0; i < bigCollection.Length; i++)
            {
                bigCollection[i] = random.Next(int.MinValue, int.MaxValue);
            }

            var watch = new Stopwatch();
            Console.WriteLine("Selection sort:");
            watch.Start();
            var sorted = bigCollection.Sort(x => x, SortingAlgorithm.SelectionSort);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Insertion sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.InsertionSort);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Bubble sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.BubbleSort);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Bubble sort (optimized):");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.BubbleSortOptimized);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Quick sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.QuickSort);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));
        }

        static int SortErrorCount(IEnumerable<int> collection)
        {
            var list = collection.ToList();
            var counter = 0;
            for (var i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                    counter++;
            }
            return counter;
        }
    }
}
