using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class BinarySearchExtension
    {
        /// <summary>
        /// The Binary search algorithm.
        /// Assumes that the list is already sorted by the key in ascending
        /// order
        /// </summary>
        /// <param name="list">The list to search</param>
        /// <param name="lookupKey">
        /// The key to use as lookup during comparisons
        /// </param>
        /// <param name="key">The key to search for</param>
        /// <typeparam name="TSource">The type contained in the list</typeparam>
        /// <typeparam name="TKey">The type of the key to search for</typeparam>
        /// <returns>
        /// The first occurrence of the value with the key searched for
        /// </returns>
        /// <exception cref="Algorithms.ValueNotFoundException">
        /// Thrown if the value searched for was not found in the collection
        /// </exception>
        public static TSource BinarySearch<TSource, TKey>(
            this IList<TSource> list, 
            Func<TSource, TKey> lookupKey,
            TKey key)
            where TKey : IComparable
        {
            var min = 0;
            var max = list.Count;
            while (min <= max)
            {
                var mid = (min + max) >> 1;
                var midVal = lookupKey(list[mid]);
                if (midVal.CompareTo(key) < 0)
                    min = mid + 1;
                else if (midVal.CompareTo(key) > 0)
                    max = mid - 1;
                else
                    return list[mid];
            }
            throw new ValueNotFoundException(
                string.Format("Key {0} was not in the list", key));
        }
    }
}
