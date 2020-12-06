using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day6
    {
        public const string Input = @".\inputs\day6.txt";
        public const string TestInput = @".\inputs\day6_testinput.txt";

        public static int PartOne()
        {
            using (var reader = new StreamReader(Input))
            {
                return PartOne(reader);
            }
        }

        public static int PartOne(TextReader reader)
        {
            return GetGroups(reader)
                .Select(group => group.SelectMany(s => s.ToCharArray()))
                .Select(group => group.Distinct().Count())
                .Sum();
        }

        public static int PartTwo()
        {
            using (var reader = new StreamReader(Input))
            {
                return PartTwo(reader);
            }
        }

        public static int PartTwo(TextReader reader)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            return GetGroups(reader)
                .Select(group => group
                    .Aggregate(alphabet, (acc, p) => acc
                        .Intersect(p)
                        .ToArray()))
                .Sum(group => group.Length);
        }

        public static IEnumerable<List<string>> GetGroups(TextReader reader)
        {
            var persons = new List<string>();

            while (true)
            {
                var person = reader.ReadLine();

                if (string.IsNullOrEmpty(person))
                {
                    yield return persons;

                    persons = new List<string>();

                    if (person == null)
                    {
                        yield break;
                    }
                }
                else
                {
                    persons.Add(person);
                }
            }
        }
        
    }
}
