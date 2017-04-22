using System;
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

        public static Link? create(int? maxId = null, int? sinceId = null)
        {
            return (maxId.HasValue || sinceId.HasValue) ? new Link(maxId, sinceId) : null as Link?;
        }

        Link(int? maxId, int? sinceId)
        {
            MaxId = maxId;
            SinceId = sinceId;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Link)) return false;
            var o = (Link) obj;
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
    }
}
