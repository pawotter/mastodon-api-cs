using System.Collections.Generic;
using System.Linq;
namespace Mastodon.API
{
    public static class Object
    {
        public static bool SequenceEqual<T>(IList<T> left, IList<T> right)
        {
            if (left == null && right == null) return true;
            if (ReferenceEquals(left, right)) return true;
            return left.SequenceEqual(right);
        }

        public static int GetHashCode(object o)
        {
            return o == null ? 0 : o.GetHashCode();
        }

        public static int GetHashCode(params object[] objects)
        {
            var hashCode = 0;
            foreach (object obj in objects)
            {
                hashCode = hashCode ^ GetHashCode(obj);
            }
            return hashCode;
        }
    }
}
