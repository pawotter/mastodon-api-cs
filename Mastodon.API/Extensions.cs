using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Mastodon.API
{
    static class Object
    {
        internal static bool SequenceEqual<T>(IList<T> left, IList<T> right)
        {
            if (left == null && right == null) return true;
            if (ReferenceEquals(left, right)) return true;
            return left.SequenceEqual(right);
        }

        internal static int GetHashCode(object o)
        {
            return o == null ? 0 : o.GetHashCode();
        }

        internal static int GetHashCode(params object[] objects)
        {
            var hashCode = 0;
            foreach (object obj in objects)
            {
                hashCode = hashCode ^ GetHashCode(obj);
            }
            return hashCode;
        }

        internal static string AsQueryString(this IDictionary<string, object> parameters)
        {
            if (parameters == null || !parameters.Any()) return "";
            var enumerable = parameters.Select(x => new KeyValuePair<string, object>(x.Key, x.Value));
            return enumerable.AsQueryString();
        }

        internal static string AsQueryString(this IEnumerable<KeyValuePair<string, object>> parameters)
        {
            if (parameters == null | !parameters.Any()) return "";
            var strings = parameters
                .Select(param => string.Format("{0}={1}", param.Key.UrlEncoded(), param.Value.UrlEncoded()));
            return "?" + string.Join("&", strings);
        }

        internal static string UrlEncoded(this object obj)
        {
            return WebUtility.UrlEncode(obj.ToString());
        }

    }
}
