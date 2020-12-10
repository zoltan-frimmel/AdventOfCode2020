using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class IO
    {

        public static int[] GetInts(string fn)
        {
            return GetLines(fn)
                .Where(s => s != "")
                .Select(int.Parse)
                .ToArray();
        }

        public static long[] GetLongs(string fn)
        {
            return GetLines(fn)
                .Where(s => s != "")
                .Select(long.Parse)
                .ToArray();
        }

        public static IEnumerable<string> GetLines(string fn)
        {
            using (var reader = new StreamReader(File.OpenRead(fn)))
            {
                do
                {
                    var line = reader.ReadLine();

                    if (line is null)
                        break;

                    yield return line;
                } while (true);
            }
        }

        public static string GetAll(string fn)
        {
            using (var reader = new StreamReader(File.OpenRead(fn)))
                return reader.ReadToEnd();
        }
    }
}
