using AdventOfCode2020;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day8Test
    {
        [Fact]
        public void TestPartOne()
        {
            var lines = IO.GetLines(Day8.TestInput);

            const int expected = 5;
            var actual = Day8.PartOne(lines);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var lines = IO.GetLines(Day8.TestInput);

            const int expected = 8;
            var actual = Day8.PartTwo(lines);

            Assert.Equal(expected, actual);
        }
    }
}
