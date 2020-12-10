using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day10
    {
        public const string Input          = @".\inputs\day10.txt";
        public const string SmallTestInput = @".\inputs\day10_small.txt";
        public const string LargeTestInput = @".\inputs\day10_large.txt";

        public static int PartOne()
        {
            return PartOne(IO.GetInts(Input));
        }

        public static int PartOne(int[] adapters)
        {
            var sorted = adapters.Append(0).OrderBy(n => n).ToArray();

            var d1s = 0;
            var d3s = 0;

            for (var i = 0; i < sorted.Length; i++)
            {
                var diff = i == 0 ? sorted[i] : sorted[i] - sorted[i - 1];

                switch (diff)
                {
                    case 1:
                        d1s++;
                        break;
                    case 3:
                        d3s++;
                        break;
                }
            }

            return d1s * (d3s + 1);
        }

        public static long PartTwo()
        {
            return PartTwo(IO.GetInts(Input));
        }

        public static long PartTwo(int[] adapters)
        {
            adapters = adapters.OrderBy(n => n).ToArray();

            return adapters
                .RunsOfCloseJoltageAdapters()
                .Select(PossibleCombinations)
                .Aggregate(1L, (c, n) => c * n);
        }

        public static long PossibleCombinations(int runLength)
        {
            // This is a cleaned up version of the code, post factum.
            // I worked out the formula for the number of invalid
            // combinations for powers of 2 > 2, which, in retrospect,
            // was a round-about way of doing this.
            switch (runLength)
            {
                case 1:       // [0, 3, 6]
                case 2:       // [0, 3, 4, 7]
                    return 1; // 2^0

                case 3:       // [0, 3, 4, 5, 8]
                    return 2; // 2^1

                case 4:       // [0, 3, 4, 5, 6, 9]
                    return 4; // 2^2

                case 5:       // [0, 3, 4, 5, 6, 7, 10]
                    return 7; // 2^3-1 (one combination is invalid)
                default:
                    throw new ArgumentOutOfRangeException(nameof(runLength));
            }
        }

        public static IEnumerable<int> RunsOfCloseJoltageAdapters(this IEnumerable<int> adapters)
        {
            var previous = 0;
            var runLength = 1;

            foreach (var current in adapters)
            {
                if (current - previous == 1)
                {
                    runLength++;
                }
                else
                {
                    yield return runLength;
                    runLength = 1;
                }

                previous = current;
            }

            yield return runLength;
        }
    }
}