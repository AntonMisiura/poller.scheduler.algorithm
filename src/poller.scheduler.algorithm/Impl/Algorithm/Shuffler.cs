using System;
using System.Collections.Generic;

namespace poller.scheduler.algorithm.Impl.Algorithm
{
    public static class Shuffler
    {
        private static Random _random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = _random.Next(n + 1);
                var value = list[k];

                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}