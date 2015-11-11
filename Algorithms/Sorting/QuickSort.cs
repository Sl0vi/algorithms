﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// The quick sort algorithm
    /// </summary>
    public class QuickSort : ISortingAlgorithm
    {
        public IEnumerable<TSource> Sort<TSource, TKey>(
            IEnumerable<TSource> collection, 
            Func<TSource, TKey> key, 
            SortOrder sortOrder = SortOrder.Ascending) 
            where TKey : IComparable
        {
            var list = collection.ToList();
            Sort(list, key, sortOrder, 0, list.Count - 1);
            return list;
        }

        /// <summary>
        /// The quick sort alogorithm. Recursively calls itself until the list is sorted.
        /// </summary>
        private void Sort<TSource, TKey>(
            List<TSource> list, 
            Func<TSource, TKey> key,
            SortOrder sortOrder,
            int first, 
            int last)
            where TKey : IComparable
        {
            if (first < last)
            {
                var split = Partition(list, key, sortOrder, first, last);
                Sort(list, key, sortOrder, first, split - 1);
                Sort(list, key, sortOrder, split + 1, last);
            }
        }

        /// <summary>
        /// Uses the value at the index of first as the pivot to partition the list.
        /// At the end of the partitioning the pivot is placed into the correct sorted position
        /// </summary>
        private int Partition<TSource, TKey>(
            List<TSource> list, 
            Func<TSource, TKey> key,
            SortOrder sortOrder,
            int first, 
            int last)
            where TKey : IComparable
        {
            var pivot = list[first];
            var leftPosition = first + 1;
            var rightPosition = last;
            var done = false;
            do
            {
                while (leftPosition <= rightPosition 
                    && IsSorted(key(list[leftPosition]), key(pivot), sortOrder))
                {
                    leftPosition++;
                }

                while (rightPosition >= leftPosition
                    && IsSorted(key(pivot), key(list[rightPosition]), sortOrder))
                {
                    rightPosition--;
                }

                if (rightPosition < leftPosition)
                    done = true;
                else
                    list.Swap(leftPosition, rightPosition);
            } while(!done);
            list.Swap(first, rightPosition);
            return rightPosition;
        }

        /// <summary>
        /// Determines if the left and right values are in correct sort order compared to each other
        /// </summary>
        private bool IsSorted<TKey>(TKey left, TKey right, SortOrder sortOrder)
            where TKey : IComparable
        {
            return (left.CompareTo(right) <= 0 && sortOrder == SortOrder.Ascending)
                || (left.CompareTo(right) >= 0 && sortOrder == SortOrder.Descending);
        }
    }
}