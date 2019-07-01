using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGRandomGenerator.Utility
{
    public static class Extensions
    {
        private static readonly Random _random = new Random();

        public static T Random<T>(this T[] sequence)
        {
            if (!sequence.Any()) return default(T);
            return sequence[_random.Next(sequence.Length)];
        }
    }
}
