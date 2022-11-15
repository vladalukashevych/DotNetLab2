using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.Extensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static int CountOccurenses(this string str, char c)
        {
            int count = str.Count(strC => (strC == c));
            return count;
        }
    }
}
