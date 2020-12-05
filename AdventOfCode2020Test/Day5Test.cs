using System;
using System.Collections.Generic;
using AdventOfCode2020;
using Xunit;

namespace AdventOfCode2020Test
{
    public class Day5Test
    {
        public static IEnumerable<object[]> PartOneTestData()
        {
            var seats = new[]
            {
                new ExpectedSeat {Row = 70, Col  = 7, Id = 567},
                new ExpectedSeat {Row = 14, Col  = 7, Id = 119},
                new ExpectedSeat {Row = 102, Col = 4, Id = 820}
            };

            var passes = new[]
            {
                "BFFFBBFRRR",
                "FFFBBBFRRR",
                "BBFFBBFRLL"
            };

            for (var i = 0; i < 3; i++)
                yield return new object[] {passes[i], seats[i]};
        }

        public class ExpectedSeat
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Id { get; set; }
        }

        [Theory]
        [MemberData(nameof(PartOneTestData))]
        public void PartOne(string boardingPass, ExpectedSeat expected)
        {
            var actual = Day5.Parse(boardingPass);

            Assert.Equal(expected.Row, actual.Row);
            Assert.Equal(expected.Col, actual.Col);
            Assert.Equal(expected.Id, actual.Id);
        }
    }
}