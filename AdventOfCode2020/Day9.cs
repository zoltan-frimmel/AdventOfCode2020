using System;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day9
    {
        public const string Input     = @".\inputs\day9.txt";
        public const string TestInput = @".\inputs\Day9_TestInput.txt";

        public static long PartOne()
        {
            var nums = IO.GetLongs(Input);

            return PartOne(nums, 25);
        }

        public static long PartOne(long[] nums, int preamble)
        {
            for (var i = preamble; i < nums.Length; i++)
            {
                if (!IsValid(nums[i], nums, i - 1, preamble))
                    return nums[i];
            }

            throw new InvalidOperationException("All numbers are valid! That was unexpected.");
        }

        public static long PartTwo()
        {
            const long seed = 257342611; // Result from previous step.
            var nums = IO.GetLongs(Input);

            return PartTwo(nums, seed);
        }

        public static long PartTwo(long[] nums, long target)
        {
            var detector = new WeaknessDetector(nums, target);

            return detector.Search();
        }

        public static bool IsValid(long num, long[] nums, int ix, int preamble)
        {
            var ixe = ix - preamble;

            for (var i = ix; i > ixe; i--)
            {
                var diff = num - nums[i];
                for (var j = i - 1; j > ixe; j--)
                {
                    if (diff == nums[j])
                        return true;
                }
            }

            return false;
        }

        public class WeaknessDetector
        {
            private readonly long[] _nums;

            public WeaknessDetector(long[] nums, long target)
            {
                _nums   = nums;
                Target  = target;
                IxStart = 0;
                IxEnd   = 1;
                Sum     = _nums[IxStart] + _nums[IxEnd];
            }

            public long Target { get; }
            public int IxStart { get; private set; }
            public int IxEnd { get; private set; }
            public long Sum { get; private set; }

            public long Search()
            {
                State state = Grow;

                while (state != null)
                {
                    state = state();
                }

                var range = Enumerable.Range(IxStart, IxEnd - IxStart).Select(ix => _nums[ix]);

                return range.Min() + range.Max();
            }

            private delegate State State();

            private State Grow()
            {
                while (Sum < Target)
                    Sum += _nums[++IxEnd];

                if (Sum == Target)
                    return null;

                return StepUp;
            }

            private State Shrink()
            {
                while (Sum > Target)
                    Sum -= _nums[IxEnd--];

                if (Sum == Target)
                    return null;

                return StepUp;
            }

            private State StepUp()
            {
                Sum -= _nums[IxStart++];

                if (Sum == Target)
                    return null;

                if (Sum < Target)
                    return Grow;

                return Shrink;
            }
        }
    }
}