using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String CombineUrl(params String[] parts)
        {
            StringBuilder sb = new();
            bool wasNull = false;
            foreach (String part in parts)
            {
                if (part is null)
                {
                    wasNull = true;
                    continue;
                }
                if (wasNull)
                {
                    throw new ArgumentException("Non-Null argument after Null one");
                }
                String p = part;
                if (!p.StartsWith('/')) p = '/' + p;
                if (p.EndsWith("/")) p = p[..^1];
                sb.Append(p);
            }
            if (sb.Length == 0)
            {
                throw new ArgumentException("All arguments are null");
            }
            return sb.ToString();
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
