using System.IO;
using AdventOfCode2020;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day6Test
    {
        [Fact]
        public void TestPartOne()
        {
            using (var reader = new StreamReader(File.OpenRead(Day6.TestInput)))
            {
                Assert.Equal(11, Day6.PartOne(reader));
            }
        }

        [Fact]
        public void TestPartTwo()
        {
            using (var reader = new StreamReader(File.OpenRead(Day6.TestInput)))
            {
                Assert.Equal(6, Day6.PartTwo(reader));
            }
        }
    }
}
