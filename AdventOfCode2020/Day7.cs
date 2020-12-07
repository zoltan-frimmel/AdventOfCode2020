using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day7
    {
        public const string Input            = @".\inputs\day7.txt";
        public const string PartOneTestInput = @".\inputs\Day7_PartOne.txt";
        public const string PartTwoTestInput = @".\inputs\Day7_PartTwo.txt";

        public static int PartOne()
        {
            return PartOne(IO.GetLines(Input));
        }

        public static int PartOne(IEnumerable<string> input)
        {
            var parser = new BagParser(input);

            parser.Parse();

            var ourBag = parser.Bags["shiny gold"];
            var stack = new Stack<Bag>(ourBag.ContainedBy);
            var visited = new HashSet<Bag>();

            while (stack.Count > 0)
            {
                var bag = stack.Pop();
                visited.Add(bag);

                foreach(var parent in bag.ContainedBy)
                    stack.Push(parent);
            }

            return visited.Count;
        }

        public static int PartTwo()
        {
            return PartTwo(IO.GetLines(Input));
        }

        public static int PartTwo(IEnumerable<string> input)
        {
            var parser = new BagParser(input);
            parser.Parse();
            
            var ourbag = parser.Bags["shiny gold"];
            var stack = new Stack<Bag>();
            stack.Push(ourbag);

            var counter = -1; // We don't want to count our own bag.
            while (stack.Count > 0)
            {
                counter++;
                var currentBag = stack.Pop();

                foreach(var bagContent in currentBag.Contents)
                {
                    for (var i = 0; i < bagContent.Count; i++)
                        stack.Push(bagContent.Bag);
                }
            }

            return counter;
        }

        public sealed class BagParser
        {
            public BagParser(IEnumerable<string> lines)
            {
                Lines = lines;
            }

            public IEnumerable<string> Lines { get; }
            public bool IsFinished { get; } = false;
            public Dictionary<string, Bag> Bags { get; } = new Dictionary<string, Bag>();

            public void Parse()
            {
                if (IsFinished)
                    return;

                foreach (var line in Lines)
                {
                    ParseLine(line);
                }
            }

            private void ParseLine(string line)
            {
                var parts = line.Split(' ');

                var parent = EnsureExists(ToColor(parts[0], parts[1]));

                if (parts.Length % 4 != 0)
                    return;

                for (var i = 4; i < parts.Length; i += 4)
                {
                    var count = int.Parse(parts[i]);
                    var color = ToColor(parts[i + 1], parts[i + 2]);
                    var bag = EnsureExists(color);
                    var content = new BagContent(bag, count);

                    parent.Contents.Add(content);
                    bag.ContainedBy.Add(parent);
                }
            }

            private Bag EnsureExists(string color)
            {
                if (!Bags.ContainsKey(color))
                {
                    Bags[color] = new Bag(color);
                }

                return Bags[color];
            }

            private static string ToColor(string adj, string color)
            {
                return $"{adj} {color}";
            }
        }

        public sealed class Bag
        {
            public Bag(string color)
            {
                Color = color;
            }

            public string Color { get; }
            public List<Bag> ContainedBy { get; } = new List<Bag>();
            public List<BagContent> Contents { get; } = new List<BagContent>();
        }

        public sealed class BagContent
        {
            public BagContent(Bag bag, int count)
            {
                Bag   = bag;
                Count = count;
            }

            public Bag Bag { get; }
            public int Count { get; }
        }
    }
}