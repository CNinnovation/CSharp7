using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Samples.Helpers
{
    public static class StringCollectionExtensions
    {
        public static void MoveElementsTo(this IList<string> coll, out string s1, out string s2)
        {
            if (coll.Count != 2) throw new ArgumentException("bad collection count");

            s1 = coll[0];
            s2 = coll[1];
        }
    }
}
