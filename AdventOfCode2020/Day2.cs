using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day2
    {
        public const string Input   = @".\inputs\day2.txt";
        public const string Pattern = @"(?<min>\d+)-(?<max>\d+) (?<char>[a-zA-Z]): (?<input>[a-zA-Z]+)";

        public static int PartOne()
        {
            return IO.GetLines(Input)
                .Select(ToElements)
                .Count(OldJobRule);
        }

        public static int PartTwo()
        {
            return IO.GetLines(Input)
                .Select(ToElements)
                .Count(CurrentRule);
        }

        public static bool OldJobRule(Element e)
        {
            var count = e.Data.Count(c => c == e.Character);

            return e.First <= count && count <= e.Second;
        }

        public static bool CurrentRule(Element e)
        {
            var ca = e.Data[e.First - 1];
            var cb = e.Data[e.Second - 1];
            var c = e.Character;

            return ca == c ^ cb == c;
        }

        public static Element ToElements(string line)
        {
            var m = Regex.Match(line, Pattern);

            Debug.Assert(m.Success, "REGEX ERROR.");

            var first = int.Parse(m.Groups["min"].Value);
            var second = int.Parse(m.Groups["max"].Value);
            var character = m.Groups["char"].Value.Single();
            var data = m.Groups["input"].Value;

            return new Element(first, second, character, data);
        }

        public sealed class Element
        {
            public Element(int first, int second, char character, string data)
            {
                First     = first;
                Second    = second;
                Character = character;
                Data      = data;
            }

            public int First { get; }
            public int Second { get; }
            public char Character { get; }
            public string Data { get; }
        }
    }
}