using System;
using System.Linq;
using System.Reflection;
using static System.ConsoleColor;

namespace AdventOfCode2020
{
    public static class Program
    {
        static void Main()
        {
            var assembly = typeof(Program).Assembly;
            WriteLine("===============================", Yellow);
            WriteLine("*.-.* Advent of Code 2020 *.-.*", Yellow);
            WriteLine("===============================", Yellow);
            
            // For each day 1-24, get the two public methods PartOne and PartTwo, evaluate and print the results.
            Enumerable
                .Range(1, 24)
                .ForEach(
                    day =>
                    {
                        var t = assembly.GetType($"AdventOfCode2020.Day{day}");

                        PrintResults(day, t);
                    });

            WriteLine("===============================", Yellow);
        }

        public static void PrintResults(int day, Type t)
        {
            if (t is null)
            {
                var blanks = new string('*', 10);
                WriteLine($"{day,2}. a) {blanks} b) {blanks}", DarkGray);
                return;
            }

            // Three possibilities here:
            // 1. We have the type, but no methods.              --> Print date. in gray
            // 2. We have the type and part one.                 --> Print date. a) <answer> in gray.
            // 3. We have the type and both part one and two.    --> Print date. a) <answer> b) <answer> in yellow

            var p1 = t.GetMethod("PartOne", Type.EmptyTypes);
            var p2 = t.GetMethod("PartTwo", Type.EmptyTypes);

            Write($"{day,2}. ", p1 != null ? Yellow : DarkGray);
            Write($"a) {ResultToString(p1)} ", p1 != null ? Yellow : DarkGray);
            Write($"b) {ResultToString(p2)}", p2 != null ? Yellow : DarkGray);
            WriteLine();
        }

        public static void Write(string s = "", ConsoleColor c = White)
        {
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void WriteLine(string s = "", ConsoleColor c = White)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static string ResultToString(MethodInfo mi)
        {
            return mi != null
                ? $"{mi.Invoke(null, null),10}"
                : new string('*', 10);
        }
    }
}