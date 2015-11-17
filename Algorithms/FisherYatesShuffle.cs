using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class FisherYatesShuffle
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            return Shuffle(collection, new CryptoRandom());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection, Random random)
        {
            var list = collection.ToList();
            for (var i = 0; i < list.Count - 1; i++)
            {
                var j = random.Next(i, list.Count);
                list.Swap(i, j);
            }
            return list;
        }
    }
}
