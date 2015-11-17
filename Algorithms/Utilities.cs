using System.Collections.Generic;

namespace Algorithms
{
    public static class Utilities
    {
        /// <summary>
        /// Helper methods that swaps two values in a list
        /// </summary>
        /// <param name="list">The list with the values to swap</param>
        /// <param name="indexA">The index of the first value to swap</param>
        /// <param name="indexB">The index of the second value to swap</param>
        /// <typeparam name="T">The type of the objects contained in the list</typeparam>
        internal static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
}
