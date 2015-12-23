using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The base interface that all sorting algorithms must implement
    /// </summary>
    public interface ISortingAlgorithm
    {
        /// <summary>
        /// Sorts the specified collection
        /// </summary>
        /// <param name="collection">The collection to sort</param>
        /// <param name="key">The key that the collection is sorted by</param>
        /// <param name="sortOrder">
        /// The order that the collection is sorted in
        /// </param>
        /// <typeparam name="TSource">
        /// The type of objects contained in the collection
        /// </typeparam>
        /// <typeparam name="TKey">The type of the sort key</typeparam>
        IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, 
            SortOrder sortOrder = SortOrder.Ascending)
            where TKey : IComparable;
    }
}
