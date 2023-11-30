using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String CombineUrl(String part1, String part2)
        {
            if (!part1.StartsWith('/')) part1 = '/' + part1;
            if (part1.EndsWith("/")) part1 = part1[..^1];

            if (!part2.StartsWith('/')) part2 = '/' + part2;
            if (part2.EndsWith("/")) part2 = part2[..^1];
            if (part1.EndsWith("/.."))
            {
                int lastSlashIndex = part1.LastIndexOf('/', part1.Length - 4);
                if (lastSlashIndex >= 0)
                {
                    part1 = part1.Substring(0, lastSlashIndex);
                }
            }

            return $"{part1}{part2}";
        }
        public String Ellipsis(String input, int len)
        {
            //return (len == 5) ? "He..." : "Hel...";
            //return $"{"Hel"[..(len-3)]}...";
            return $"{input[..(len - 3)]}...";
        }
        public String Finalize(String input)
        {
            if (string.IsNullOrEmpty(input) || input.EndsWith("."))
            {
                return input;
            }
            return input + ".";
        }
    }

}
