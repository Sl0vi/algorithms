using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Algorithms.Sorting;

namespace Algorithms.ConsoleTests
{
    static class MainClass
    {
        static Random random = new Random();

        public static void Main(string[] args)
        {
            int workerThreads;
            int completionPortThreads;
            ThreadPool.GetMaxThreads(
                out workerThreads, 
                out completionPortThreads);
            Console.WriteLine($"{workerThreads}, {completionPortThreads}");
            //ShuffleNumbers();
            SortingTests();
            //QuickSorts();
            Console.WriteLine("Done, press any key to exit");
            Console.ReadKey(true);
        }

        static void ShuffleNumbers()
        {
            var random = new Random(243);
            var sorted = new[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("Shuffling numbers:");
            Console.Write("Unshuffled: ");
            for (var i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i]);
                if (i < sorted.Length - 1)
                    Console.Write(", ");
            }
            Console.Write(Environment.NewLine);
            Console.Write("Shuffled: ");
            var shuffled = sorted.Shuffle(random).ToArray();
            for (var i = 0; i < shuffled.Length; i++)
            {
                Console.Write(shuffled[i]);
                if (i < shuffled.Length - 1)
                    Console.Write(", ");
            }
            Console.Write(Environment.NewLine);
        }

        static void DoStuff(int number)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(
                    "Task {0}: says hi! Running thread: {1}",
                    number,
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(random.Next(20, 500));
            }
        }

        static void SortingTests()
        {
            var warmup = new[] { 30, 2, 18, 20, 5, 36, 19 };

            warmup.Sort(x => x, SortingAlgorithm.SelectionSort);
            warmup.Sort(x => x, SortingAlgorithm.InsertionSort);
            warmup.Sort(x => x, SortingAlgorithm.BubbleSort);
            warmup.Sort(x => x, SortingAlgorithm.BubbleSortOptimized);
            warmup.Sort(x => x, SortingAlgorithm.QuickSort);
            warmup.Sort(x => x, SortingAlgorithm.QuickSortParallel);
            warmup.Sort(x => x, SortingAlgorithm.MergeSort);
            warmup.Sort(x => x, SortingAlgorithm.ShellSort);

            var bigCollection = new int[100000];
            for (var i = 0; i < bigCollection.Length; i++)
            {
                bigCollection[i] = random.Next(int.MinValue, int.MaxValue);
            }

            GC.Collect();

            var watch = new Stopwatch();
            Console.WriteLine("Selection sort:");
            watch.Start();
            var sorted = bigCollection
                .Sort(x => x, SortingAlgorithm.SelectionSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Insertion sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.InsertionSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Bubble sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.BubbleSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Bubble sort (optimized):");
            watch.Start();
            sorted = bigCollection
                .Sort(x => x, SortingAlgorithm.BubbleSortOptimized);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Quick sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.QuickSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Quick sort (parallel):");
            watch.Start();
            sorted = bigCollection
                .Sort(x => x, SortingAlgorithm.QuickSortParallel);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));
            
            watch.Reset();
            sorted = null;
            GC.Collect();
            
            Console.WriteLine("Merge sort:");
            watch.Start();
            sorted = bigCollection
                .Sort(x => x, SortingAlgorithm.MergeSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));
            
            watch.Reset();
            sorted = null;
            GC.Collect();
            
            Console.WriteLine("Shell sort:");
            watch.Start();
            sorted = bigCollection
                .Sort(x => x, SortingAlgorithm.ShellSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));
        }

        static void QuickSorts()
        {
            var warmup = new[] { 30, 2, 18, 20, 5, 36, 19 };

            warmup.Sort(x => x, SortingAlgorithm.SelectionSort);
            warmup.Sort(x => x, SortingAlgorithm.InsertionSort);
            warmup.Sort(x => x, SortingAlgorithm.BubbleSort);
            warmup.Sort(x => x, SortingAlgorithm.BubbleSortOptimized);
            warmup.Sort(x => x, SortingAlgorithm.QuickSort);

            var bigCollection = new int[10000000];
            for (var i = 0; i < bigCollection.Length; i++)
            {
                bigCollection[i] = random.Next(int.MinValue, int.MaxValue);
            }

            GC.Collect();
            var watch = new Stopwatch();
            IEnumerable<int> sorted;

            Console.WriteLine("Quick sort:");
            watch.Start();
            sorted = bigCollection.Sort(x => x, SortingAlgorithm.QuickSort);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));

            watch.Reset();
            sorted = null;
            GC.Collect();

            Console.WriteLine("Quick sort (parallel):");
            watch.Start();
            sorted = bigCollection
                .Sort(x => x, SortingAlgorithm.QuickSortParallel);
            watch.Stop();
            Console.WriteLine(
                "Sorted {0} items, time: {1}", 
                bigCollection.Length, 
                watch.Elapsed);
            Console.WriteLine("Sort Errors: {0}", SortErrorCount(sorted));
        }

        static int SortErrorCount(IEnumerable<int> collection)
        {
            var list = collection.ToList();
            var counter = 0;
            for (var i = 0; i >= list.Count - 1; i++)
            {
                if (list[i] < list[i + 1])
                    counter++;
            }
            return counter;
        }
    }
}
