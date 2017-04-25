using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Mastodon.API
{
    public struct Link
    {
        /// <summary>
        /// Get a list with ID less than or equal this value
        /// </summary>
        /// <value>The max identifier.</value>
        public int? MaxId { get; }

        /// <summary>
        /// Get a list with ID greater than this value
        /// </summary>
        /// <value>The since identifier.</value>
        public int? SinceId { get; }

        public static Link? Create(int? maxId = null, int? sinceId = null)
        {
            if (maxId.HasValue || sinceId.HasValue) return new Link(maxId, sinceId);
            return null;
        }

        public static Link? Create(HttpHeaders headers)
        {
            var linkHeader = GetValueFromHeaders("Link", headers);
            if (linkHeader == null) return null;
            return CreateLinkFromHeaderLinkValue(linkHeader);
        }

        Link(int? maxId, int? sinceId)
        {
            MaxId = maxId;
            SinceId = sinceId;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Link)) return false;
            var o = (Link)obj;
            return Equals(MaxId, o.MaxId) &&
                Equals(SinceId, o.SinceId);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(MaxId, SinceId);
        }

        public override string ToString()
        {
            return string.Format("[Link: MaxId={0}, SinceId={1}]", MaxId, SinceId);
        }

        internal static string GetValueFromHeaders(string key, HttpHeaders headers)
        {
            if (headers == null) return null;
            return headers
                .Where(x => x.Key.Equals(key))
                .Select(x => x.Value)
                .First().First();
        }

        internal static Link? CreateLinkFromHeaderLinkValue(string headerLinkValue)
        {
            if (headerLinkValue == null) return null;
            var kvs = headerLinkValue.Split(',')
                       .Select(x => Regex.Match(x, "<http.+[&|?](max_id|since_id)=(\\d+).*>;\\s*rel=\"(next|prev)\"").Groups)
                       .Select(x => new KeyValuePair<string, string>(x[1].ToString(), x[2].ToString()));
            int? maxId = null;
            int? sinceId = null;
            foreach (var kv in kvs)
            {
                if (kv.Key.Equals("max_id")) maxId = int.Parse(kv.Value);
                if (kv.Key.Equals("since_id")) sinceId = int.Parse(kv.Value);
            }
            return Create(maxId, sinceId);
        }
    }
}
