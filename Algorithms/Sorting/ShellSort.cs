using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The Shell sort algorithm
    /// </summary>
    public class ShellSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection,
            Func<TSource, TKey> key,
            SortOrder sortOrder = SortOrder.Ascending)
            where TKey : IComparable
        {
            var list = collection.ToList();
            for (var gap = list.Count / 2; gap > 0; gap /= 2)
            {
                for (int i = 0; i < list.Count - gap; i++)
                {
                    var j = i + gap;
                    var temp = list[j];
                    while (j >= gap && 
                        Utilities.IsSorted(
                            key(temp), 
                            key(list[j - gap]),
                            sortOrder))
                    {
                        list[j] = list[j - gap];
                        j -= gap;
                    }
                    list[j] = temp;
                }
            }
            return list;
        }
    }
}
