using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
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
                while (x > 0 
                    && ((key(list[x]).CompareTo(key(list[x - 1])) < 0 && sortOrder == SortOrder.Ascending)
                    || (key(list[x]).CompareTo(key(list[x - 1])) > 0 && sortOrder == SortOrder.Descending)))
                {
                    list.Swap(x, x - 1);
                    x--;
                }
            }
            return list;
        }
    }
}
