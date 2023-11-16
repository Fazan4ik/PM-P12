using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
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
