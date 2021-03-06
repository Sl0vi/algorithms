﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The bubble sort algorithm
    /// </summary>
    public class BubbleSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, SortOrder sortOrder = SortOrder.Ascending) 
            where TKey : IComparable
        {
            var list = collection.ToList();
            var swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < list.Count - 1; i++)
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
            } while (swapped == true);
            return list;
        }
    }
}
