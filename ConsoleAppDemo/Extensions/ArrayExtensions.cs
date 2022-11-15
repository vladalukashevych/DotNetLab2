using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.Extensions
{
    public static class ArrayExtensions
    {
        public static int CountOccurenses<T>(this T[] array, T item) where T : struct
        {
             var numQuery =
                from elem in array
                where Comparer<T>.Default.Compare(elem, item) == 0
                select elem;

            return numQuery.Count();
        }

        public static T[] GetUnique<T>(this T[] array) where T : struct
        {
            return array.Distinct().ToArray();
        }
    }
}
