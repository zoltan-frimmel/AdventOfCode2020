using System.Text;

namespace AdventOfCode2020
{
    public static class Day3
    {
        public const string Input = @".\inputs\day3.txt";
        public const char   Space = '.';
        public const char   Tree  = '#';

        public static int PartOne()
        {
            var (width, height, map) = ReadMap();

            return FindCollisions(3, 1, width, height, map);
        }

        public static int PartTwo()
        {
            var (width, height, map) = ReadMap();

            return
                FindCollisions(1, 1, width, height, map) *
                254 *
                FindCollisions(5, 1, width, height, map) *
                FindCollisions(7, 1, width, height, map) *
                FindCollisions(1, 2, width, height, map);
        }

        public static int FindCollisions(int stepX, int stepY, int width, int height, string map)
        {
            var x = 0;
            var y = 0;
            var treeCounter = 0;

            while (y < height)
            {
                var ix = y * width + x;

                treeCounter += map[ix] == Tree ? 1 : 0;

                x =  (x + stepX) % width;
                y += stepY;
            }

            return treeCounter;
        }

        public static (int, int, string) ReadMap()
        {
            var sb = new StringBuilder();
            var width = 0;
            var lines = 0;
            foreach (var line in IO.GetLines(Input))
            {
                lines++;
                width = line.Length;
                sb.Append(line);
            }

            return (width, lines, sb.ToString());
        }
    }
}