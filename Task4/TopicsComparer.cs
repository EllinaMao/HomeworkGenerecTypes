using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task4
{
    public class TopicsComparer : IEqualityComparer<Topics>
    {
        public bool Equals(Topics? x, Topics? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return Normalize(x.Name) == Normalize(y.Name) &&
                   Normalize(x.Teacher) == Normalize(y.Teacher);
        }

        public int GetHashCode(Topics obj)
        {
            return HashCode.Combine(Normalize(obj.Name), Normalize(obj.Teacher));
        }

        private static string Normalize(string value)
        {
            return value.Trim().ToLowerInvariant();
        }
    }
}