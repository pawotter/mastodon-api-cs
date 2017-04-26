using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Tag.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#tag
    /// </summary>
    public class Tag
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }

        internal Tag() { }

        Tag(string name, Uri url)
        {
            Name = name;
            Url = url;
        }

        public static Tag create(string name, Uri url)
        {
            return new Tag(name, url);
        }

        public override string ToString()
        {
            return string.Format("[Tag: Name={0}, Url={1}]", Name, Url);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Tag;
            if (o == null) return false;
            return Equals(Name, o.Name) &&
                Equals(Url, o.Url);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Name, Url);
        }
    }
}
