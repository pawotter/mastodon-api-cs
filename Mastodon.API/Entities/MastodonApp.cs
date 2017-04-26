using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    public class MastodonApp
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }
        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }
        [JsonProperty(PropertyName = "redirect_uri")]
        public Uri RedirectUri { get; set; }

        internal MastodonApp() { }

        MastodonApp(string id, string clientId, string clientSecret, Uri redirectUri)
        {
            Id = id;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        public static MastodonApp create(string id, string clientId, string clientSecret, Uri redirectUri)
        {
            return new MastodonApp(id, clientId, clientSecret, redirectUri);
        }

        public override bool Equals(object obj)
        {
            var o = obj as MastodonApp;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(ClientId, o.ClientId) &&
                Equals(ClientSecret, o.ClientSecret) &&
                Equals(RedirectUri, o.RedirectUri);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, ClientId, ClientSecret, RedirectUri);
        }

        public override string ToString()
        {
            return string.Format("[MastodonApp: Id={0}, ClientId={1}, ClientSecret={2}, RedirectUri={3}]", Id, ClientId, ClientSecret, RedirectUri);
        }
    }
}
