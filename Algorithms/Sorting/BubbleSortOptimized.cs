using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// An optimized version of the bubble sort algorithm
    /// </summary>
    public class BubbleSortOptimized : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, SortOrder sortOrder = SortOrder.Ascending) 
            where TKey : IComparable
        {
            var list = collection.ToList();
            var swapped = false;
            var swaps = 0;
            do
            {
                swapped = false;
                for (int i = 0; i < list.Count - swaps - 1; i++)
                {
                    if (!Utilities.IsSorted(
                        key(list[i]), 
                        key(list[i + 1]),
                        sortOrder))
                    {
                        list.Swap(i, i + 1);
                        swapped = true;
                    }
                }
                swaps++;
            } while (swapped == true);
            return list;
        }
    }
}
