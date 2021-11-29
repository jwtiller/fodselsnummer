using System;
using System.Collections.Generic;

namespace Fnr
{
    public static class ExtensionMethods
    {
        public static int Length(this int value)
        {
            return (int)Math.Floor(Math.Log10(value)) + 1;
        }

        public static int[] Split(this int value)
        {
            if (value == 0)
                return new int[] { 0 };
            var listOfInts = new List<int>();
            while (value > 0)
            {
                listOfInts.Add(value % 10);
                value = value / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }

    }
}
