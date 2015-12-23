using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The selection sort algorithm
    /// </summary>
    public class SelectionSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, 
            SortOrder sortOrder = SortOrder.Ascending)
            where TKey : IComparable
        {
            var list = collection.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                var next = i;
                for (var x = i + 1; x < list.Count; x++)
                {
                    if (!Utilities.IsSorted(
                        key(list[next]),
                        key(list[x]),
                        sortOrder))
                    {
                        next = x;
                    }
                }
                if (next != i)
                    list.Swap(i, next);
            }
            return list;
        }
    }
}
