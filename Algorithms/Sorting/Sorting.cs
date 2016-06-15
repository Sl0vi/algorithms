using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Lets you sort collections using various sorting algorithms
    /// </summary>
    public static class Sorting
    {
        static readonly Dictionary<SortingAlgorithm, Type> sortingAlgorithms;

        static Sorting()
        {
            sortingAlgorithms = new Dictionary<SortingAlgorithm, Type>();
            sortingAlgorithms.Add(
                SortingAlgorithm.SelectionSort, 
                typeof(SelectionSort));
            sortingAlgorithms.Add(
                SortingAlgorithm.InsertionSort, 
                typeof(InsertionSort));
            sortingAlgorithms.Add(
                SortingAlgorithm.BubbleSort, 
                typeof(BubbleSort));
            sortingAlgorithms.Add(
                SortingAlgorithm.BubbleSortOptimized, 
                typeof(BubbleSortOptimized));
            sortingAlgorithms.Add(
                SortingAlgorithm.QuickSort, 
                typeof(QuickSort));
            sortingAlgorithms.Add(
                SortingAlgorithm.QuickSortParallel, 
                typeof(QuickSortParallel));
            sortingAlgorithms.Add(
                SortingAlgorithm.MergeSort,
                typeof(MergeSort));
            sortingAlgorithms.Add(
                SortingAlgorithm.ShellSort,
                typeof(ShellSort));
        }

        /// <summary>
        /// Sorts a collection using the specified algorithm
        /// </summary>
        /// <param name="collection">The collection to sort</param>
        /// <param name="key">The key that the collection is sorted by</param>
        /// <param name="algorithm">
        /// The algorithm used to sort the collection
        /// </param>
        /// <param name="sortOrder">
        /// The order that the collection is sorted in
        /// </param>
        /// <typeparam name="TSource">
        /// The type of objects contained in the collection
        /// </typeparam>
        /// <typeparam name="TKey">The type of the sort key</typeparam>
        public static IEnumerable<TSource> Sort<TSource, TKey>(
            this IEnumerable<TSource> collection,
            Func<TSource, TKey> key,
            SortingAlgorithm algorithm,
            SortOrder sortOrder = SortOrder.Ascending)
            where TKey : IComparable
        {
            var type = sortingAlgorithms[algorithm];
            var algorithmInstance = (ISortingAlgorithm)Activator
                .CreateInstance(type);
            return algorithmInstance.Sort(collection, key, sortOrder);
        }
    }
}
