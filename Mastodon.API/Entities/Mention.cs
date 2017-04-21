using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Mastodon.API
{
    /// <summary>
    /// Mention.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#mention
    /// </summary>
    public class Mention
    {
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "acct")]
        public string Acct { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public Mention(Uri url, string username, string acct, string id)
        {
            Url = url;
            Username = username;
            Acct = acct;
            Id = id;
        }

        public override string ToString()
        {
            return string.Format("[Mention: Url={0}, Username={1}, Acct={2}, Id={3}]", Url, Username, Acct, Id);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Mention;
            if (o == null) return false;
            return Equals(Url, o.Url) &&
                Equals(Username, o.Username) &&
                Equals(Acct, o.Acct) &&
                Equals(Id, o.Id);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Url, Username, Acct, Id);
        }
    }
}
