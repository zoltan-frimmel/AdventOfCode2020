using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day8
    {
        public const string Input     = @".\inputs\day8.txt";
        public const string TestInput = @".\inputs\day8_testinput.txt";


        public const string NOP = "nop";
        public const string ACC = "acc";
        public const string JMP = "jmp";

        public static int PartOne()
        {
            return PartOne(IO.GetLines(Input));
        }

        public static int PartOne(IEnumerable<string> lines)
        {
            var program = lines.ToList();
            var visited = Enumerable.Repeat(false, program.Count).ToArray();

            foreach (var frame in Run(program))
            {
                if (visited[frame.NextInstruction])
                    return frame.Value;

                visited[frame.CurrentInstruction] = true;
            }

            return -1;
        }

        public static int PartTwo()
        {
            return PartTwo(IO.GetLines(Input));
        }

        public static int PartTwo(IEnumerable<string> lines)
        {
            var program = lines.ToList();

            // We need to rewrite the program by flipping nop -> jmp and jmp -> nop
            // Select the indicies of all possible lines, create a new program for each
            // and run it!

            var results = program.Select(
                    (instruction, address) =>
                        instruction.StartsWith(NOP) || instruction.StartsWith(JMP) ? address : -1)
                .Where(address => address >= 0)
                .Select(
                    address =>
                    {
                        var newProgram = ReWrite(program, address);

                        var visited = Enumerable.Repeat(false, program.Count).ToArray();
                        var result = 0;
                        foreach (var frame in Run(newProgram))
                        {
                            if (frame.NextInstruction >= newProgram.Count)
                            {
                                result = frame.Value;
                                break;
                            }

                            if (visited[frame.NextInstruction])
                                return -1;

                            visited[frame.CurrentInstruction] = true;
                        }

                        return result;
                    })
                .ToList();

            return results.Single(result => result > -1);
        }

        public static List<string> ReWrite(List<string> program, int address)
        {
            var newProgram = program.ToList();
            var instruction = newProgram[address];
            newProgram[address] = instruction.StartsWith(NOP)
                ? instruction.Replace(NOP, JMP)
                : instruction.Replace(JMP, NOP);

            return newProgram;
        }

        public static IEnumerable<Frame> Run(List<string> program)
        {
            var i = 0;
            var acc = 0;

            while (true)
            {
                if (i >= program.Count)
                    yield break;

                var instr = program[i].Split(' ');
                var opCode = instr[0];
                var args = instr[1];

                switch (opCode)
                {
                    case NOP:
                        yield return new Frame(i, ++i, acc, acc);
                        break;
                    case ACC:
                        yield return new Frame(i, ++i, acc, acc += int.Parse(args));
                        break;
                    case JMP:
                        yield return new Frame(i, i += int.Parse(args), acc, acc);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(opCode));
                }
            }
        }

        public struct Frame
        {
            public Frame(int currentInstruction, int nextInstruction, int previousValue, int value)
            {
                CurrentInstruction = currentInstruction;
                NextInstruction    = nextInstruction;
                PreviousValue      = previousValue;
                Value              = value;
            }

            public int CurrentInstruction { get; }
            public int NextInstruction { get; }
            public int PreviousValue { get; }
            public int Value { get; }
        }
    }
}