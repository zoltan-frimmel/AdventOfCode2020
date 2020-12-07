using System.Collections.Generic;
using AdventOfCode2020;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day7Test
    {
        [Fact]
        public void TestPartOne()
        {
            var lines = IO.GetLines(Day7.PartOneTestInput);
            var actual = Day7.PartOne(lines);

            Assert.Equal(4, actual);
        }

        [Theory]
        [MemberData(nameof(ParTwoTestData))]
        public void TestPartTwo(IEnumerable<string> lines, int expected)
        {
            var actual = Day7.PartTwo(lines);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ParTwoTestData()
        {
            yield return new object[] {IO.GetLines(Day7.PartOneTestInput), 32};
            yield return new object[] {IO.GetLines(Day7.PartTwoTestInput), 126};
        }
    }
}