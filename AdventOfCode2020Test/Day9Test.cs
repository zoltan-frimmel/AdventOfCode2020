using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day9Test
    {
        public static IEnumerable<object[]> PartOneIsValidExamples()
        {
            var nums = Enumerable.Range(1, 25).Select(i => (long)i).ToArray();

            yield return new object[] {nums, 26, true};
            yield return new object[] { nums, 49, true };
            yield return new object[] { nums, 100, false };
            yield return new object[] { nums, 50, false };
        }

        [Theory]
        [MemberData(nameof(PartOneIsValidExamples))]
        public void TestIsValid(long[] nums, long num, bool expected)
        {
            var actual = Day9.IsValid(num, nums, nums.Length - 1, nums.Length);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartOne()
        {
            var input = IO.GetLongs(Day9.TestInput);

            const long expected = 127;
            var actual = Day9.PartOne(input, 5);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = IO.GetLongs(Day9.TestInput);

            const long expected = 62;
            var actual = Day9.PartTwo(input, 127);

            Assert.Equal(expected, actual);
        }
    }
}