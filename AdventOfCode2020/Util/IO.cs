using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public static class IO
    {
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
    }
}
