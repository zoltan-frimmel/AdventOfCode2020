using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> a)
        {
            foreach (var t in ts)
                a(t);
        }
    }
}
