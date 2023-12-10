using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String CombineUrl(params String[] parts)
        {
            if (parts is null) { throw new NullReferenceException("Parts is null"); }
            if (parts.Length == 0) { throw new ArgumentException("Parts is empty"); }

            StringBuilder result = new();  
            string temp;
            bool wasNull = false;  
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] is null)
                {
                    wasNull = true; 
                    continue;
                }
                if (wasNull)
                {
                    throw new ArgumentException("Non-Null argument after Null one");
                }

                if (parts[i] == "..") { continue; } 
                temp = "/" + parts[i].TrimStart('/').TrimEnd('/');  

                if ((i != parts.Length - 1) && parts[i + 1] == "..") { continue; } 
                result.Append(temp);
            }
            if (result.Length == 0)
            {
                throw new ArgumentException("All arguments are null");
            }
            return result.ToString();
        }
        public String Ellipsis(String input, int len)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));  
            }
            if (len < 3)
            {
                throw new ArgumentException("Argument 'len' could not be less then 3");
            }
            if (len > input.Length)
            {
                throw new ArgumentOutOfRangeException("Argument 'len' could not be greater than input length");
            }
            return input[..(len - 3)] + "...";
        }
        public String EscapeHtml(String html)
        {
            String newHtml = html.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");

            return newHtml;
        }

        public bool ContainsAttributes(String html)
        {
            string pattern = @"<([a-z][a-z0-9]*)\s+[^>]*?(\s\w+\s*=\s*(""|').*?(""|')|[^>]+)>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(html);
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
