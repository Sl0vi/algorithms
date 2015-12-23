using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The insertion sort algorithm
    /// </summary>
    public class InsertionSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, 
            SortOrder sortOrder = SortOrder.Ascending) 
            where TKey : IComparable
        {
            var list = collection.ToList();
            for (var i = 1; i < list.Count; i++)
            {
                var x = i;
                while (x > 0 && !Utilities.IsSorted(
                    key(list[x - 1]),
                    key(list[x]),
                    sortOrder))
                {
                    list.Swap(x, x - 1);
                    x--;
                }
            }
            return list;
        }
    }
}
