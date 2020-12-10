using AdventOfCode2020;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day10Test
    {
        [Theory]
        [ClassData(typeof(PartOneTestData))]
        public void TestPartOne(string input, int expected)
        {
            var nums = IO.GetInts(input);

            var actual = Day10.PartOne(nums);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(PartTwoTestData))]
        public void TestPartTwo(string input, long expected)
        {
            var nums = IO.GetInts(input);

            var actual = Day10.PartTwo(nums);

            Assert.Equal(expected, actual);
        }

        public class PartOneTestData : TheoryData<string, int>
        {
            public PartOneTestData()
            {
                Add(Day10.SmallTestInput, 7 * 5);
                Add(Day10.LargeTestInput, 22 * 10);
            }
        }

        public class PartTwoTestData : TheoryData<string, long>
        {
            public PartTwoTestData()
            {
                Add(Day10.SmallTestInput, 8);
                Add(Day10.LargeTestInput, 19208);
            }
        }
    }
}
