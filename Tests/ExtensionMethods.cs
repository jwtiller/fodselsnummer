using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class ExtensionMethods
    {
        public static int Length(this int value)
        {
            return (int)Math.Floor(Math.Log10(value)) + 1;
        }

    }
}
