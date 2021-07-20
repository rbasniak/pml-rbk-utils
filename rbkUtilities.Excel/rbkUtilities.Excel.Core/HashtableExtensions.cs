using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rbkUtilities.Excel.Core
{
    public static class HashTableExtensions
    {
        public static Hashtable ToHashtable(this string[] data)
        {
            var table = new Hashtable();

            for (double i = 0; i < data.Length; i++)
            {
                table.Add(i + 1, data[(int)i]);
            }

            return table;
        }

        public static Hashtable ToHashtable(this int[] data)
        {
            var table = new Hashtable();

            for (double i = 0; i < data.Length; i++)
            {
                table.Add(i + 1, data[(int)i]);
            }

            return table;
        }

        public static List<T> ToList<T>(this Hashtable table)
        {
            var orderedKeys = table.Keys.Cast<double>().OrderBy(x => x).ToList();
            var allKvp = from x in orderedKeys select (T)table[x];

            return allKvp.ToList();
        }
    }
}
