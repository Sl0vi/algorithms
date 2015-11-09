using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class BubbleSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, SortOrder sortOrder = SortOrder.Ascending) 
            where TKey : IComparable
        {
            throw new NotImplementedException();
        }
    }
}
