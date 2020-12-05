using System;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day5
    {
        // So we are parsing binary numbers with MSB left-to-right.
        // F = 0, B = 1, L = 0, R = 1
        // Format XXXXXXX YYY

        public const string Input = @".\inputs\day5.txt";

        public static int PartOne()
        {
            return IO.GetLines(Input)
                .Select(Parse)
                .Select(seat => seat.Id)
                .OrderByDescending(id => id)
                .First();
        }

        public static int PartTwo()
        {
            var oids = IO.GetLines(Input)
                .Select(Parse)
                .Select(seat => seat.Id)
                .OrderBy(id => id)
                .ToArray();

            return oids
                .Zip(
                    oids.Skip(1),
                    (p, n) => n - p == 2 ? p + 1 : -1)
                .Single(id => id > -1);
        }

        public static Seat Parse(string s)
        {
            if (s.Length != 10)
                throw new ArgumentException($"Invalid seat id length: {s.Length}.");

            var id = 0;
            for (var i = 0; i < 7; i++)
            {
                if (s[i] == 'B')
                    id |= (1 << 9 - i);
            }

            for (var i = 0; i < 3; i++)
            {
                if (s[7 + i] == 'R')
                    id |= (1 << 2 - i);
            }

            return new Seat(id);
        }

        public struct Seat
        {
            public const int RowMask = 0b1111111000;
            public const int ColMask = 0b0000000111;

            public Seat(int id)
            {
                Id = id;
            }

            public int Id { get; }

            public int Row => (Id & RowMask) >> 3;
            public int Col => Id & ColMask;
            

            /// <inheritdoc />
            public override string ToString()
            {
                return $"[Seat - Row: {Row}, Col: {Col}, ID: {Id}]";
            }
        }
    }
}
