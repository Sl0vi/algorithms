using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public interface ISortingAlgorithm
    {
        IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, 
            SortOrder sortOrder = SortOrder.Ascending)
            where TKey : IComparable;
    }
}
