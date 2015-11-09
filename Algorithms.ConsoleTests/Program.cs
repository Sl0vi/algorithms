using System;
using System.Diagnostics;
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

            var bigCollection = new int[50000];
            for (var i = 0; i < bigCollection.Length; i++)
            {
                bigCollection[i] = random.Next(int.MinValue, int.MaxValue);
            }

            var watch = new Stopwatch();
            Console.WriteLine("Selection sort:");
            watch.Start();
            bigCollection.Sort(x => x, SortingAlgorithm.SelectionSort);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);

            watch.Reset();

            Console.WriteLine("Insertion sort:");
            watch.Start();
            bigCollection.Sort(x => x, SortingAlgorithm.InsertionSort);
            watch.Stop();
            Console.WriteLine("Sorted {0} items, time: {1}", bigCollection.Length, watch.Elapsed);
        }
    }
}
