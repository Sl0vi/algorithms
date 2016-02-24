using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The merge sort algorithm
    /// </summary>
    public class MergeSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey> (
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, 
            SortOrder sortOrder = SortOrder.Ascending) 
            where TKey : IComparable
        {
            var list = collection.ToList();
            return Split(list, key, sortOrder);
        }
        
        /// <summary>
        /// Recursively splits up the list and then merges them back together
        /// </summary>
        private List<TSource> Split<TSource, TKey>(
            List<TSource> list,
            Func<TSource, TKey> key,
            SortOrder sortOrder)
            where TKey : IComparable
        {
            if (list.Count < 2)
                return list;
            var mid = list.Count / 2;
            var a = Split(
                list.GetRange(0, mid).ToList(),
                key,
                sortOrder);
            var b = Split(
                list.GetRange(mid, list.Count - mid).ToList(),
                key,
                sortOrder);
            return Merge(a, b, key, sortOrder);
        }
        
        /// <summary>
        /// Merges the lists back together in correct sort order
        /// </summary>
        private List<TSource> Merge<TSource, TKey>(
            List<TSource> a,
            List<TSource> b,
            Func<TSource, TKey> key,
            SortOrder sortOrder)
            where TKey : IComparable
        {
            var mergedList = new List<TSource>();
            while (a.Count > 0 || b.Count > 0)
            {
                if (b.Count == 0 ||
                    (a.Count != 0 &&
                    Utilities.IsSorted(
                        key(a[0]),
                        key(b[0]),
                        sortOrder)))
                {
                    mergedList.Add(a[0]);
                    a.RemoveAt(0);
                }
                else
                {
                    mergedList.Add(b[0]);
                    b.RemoveAt(0);
                }
            }
            return mergedList;
        }
    }
}
