using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
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
        }

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

        internal static void Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
}
