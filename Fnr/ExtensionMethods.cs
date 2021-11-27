using System;

namespace Fnr
{
    public static class ExtensionMethods
    {
        public static int Length(this int value)
        {
            return (int)Math.Floor(Math.Log10(value)) + 1;
        }

    }
}
