using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Lets you sort collections using various sorting algorithms
    /// </summary>
    public static class Sorting
    {
        private static Dictionary<SortingAlgorithm, Type> sortingAlgorithms;

        static Sorting()
        {
            sortingAlgorithms = new Dictionary<SortingAlgorithm, Type>();
            sortingAlgorithms.Add(SortingAlgorithm.SelectionSort, typeof(SelectionSort));
            sortingAlgorithms.Add(SortingAlgorithm.InsertionSort, typeof(InsertionSort));
            sortingAlgorithms.Add(SortingAlgorithm.BubbleSort, typeof(BubbleSort));
            sortingAlgorithms.Add(SortingAlgorithm.BubbleSortOptimized, typeof(BubbleSortOptimized));
            sortingAlgorithms.Add(SortingAlgorithm.QuickSort, typeof(QuickSort));
        }

        /// <summary>
        /// Sorts a collection using the specified algorithm
        /// </summary>
        /// <param name="collection">The collection to sort</param>
        /// <param name="key">The key that the collection is sorted by</param>
        /// <param name="algorithm">The algorithm used to sort the collection</param>
        /// <param name="sortOrder">The order that the collection is sorted in</param>
        /// <typeparam name="TSource">The type of objects contained in the collection</typeparam>
        /// <typeparam name="TKey">The type of the sort key</typeparam>
        public static IEnumerable<TSource> Sort<TSource, TKey>(
            this IEnumerable<TSource> collection,
            Func<TSource, TKey> key,
            SortingAlgorithm algorithm,
            SortOrder sortOrder = SortOrder.Ascending)
            where TKey : IComparable
        {
            var type = sortingAlgorithms[algorithm];
            var algorithmInstance = (ISortingAlgorithm)Activator.CreateInstance(type);
            return algorithmInstance.Sort(collection, key, sortOrder);
        }

        /// <summary>
        /// Helper methods that swaps two values in a list
        /// </summary>
        /// <param name="list">The list with the values to swap</param>
        /// <param name="indexA">The index of the first value to swap</param>
        /// <param name="indexB">The index of the second value to swap</param>
        /// <typeparam name="T">The type of the objects contained in the list</typeparam>
        internal static void Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
}
