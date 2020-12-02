using System;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day1
    {
        public const string Input = @".\inputs\day1.txt";

        public static int PartOne()
        {
            var nums = IO.GetLines(Input)
                .Select(int.Parse)
                .ToArray();

            for (var i = 0; i < nums.Length; i++)
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == 2020)
                    return nums[i] * nums[j];
            }

            throw new InvalidOperationException("ERROR");
        }

        public static int PartTwo()
        {
            var nums = IO.GetLines(Input)
                .Select(int.Parse)
                .ToArray();

            for (var i = 0; i < nums.Length; i++)
            for (var j = i + 1; j < nums.Length; j++) 
            for(var k = j + 1; k < nums.Length; k++)
            {
                if (nums[i] + nums[j] + nums[k] == 2020)
                    return nums[i] * nums[j] * nums[k];
            }

            throw new InvalidOperationException("ERROR");
        }

    }
}
