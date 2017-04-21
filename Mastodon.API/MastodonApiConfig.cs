using System;
namespace Mastodon.API
{
    public class MastodonApiConfig
    {
        public Uri InstanceBaseUrl { get; }
        public string ClientId { get; }
        public string ClietnSecret { get; }

        public MastodonApiConfig(Uri instanceBaseUrl, string clientId, string clientSecret)
        {
            InstanceBaseUrl = instanceBaseUrl;
            ClientId = clientId;
            ClietnSecret = clientSecret;
        }

        public override string ToString()
        {
            return string.Format("[MastodonApiConfig: InstanceBaseUrl={0}, ClientId={1}, ClietnSecret={2}]", InstanceBaseUrl, ClientId, ClietnSecret);
        }

        public override bool Equals(object obj)
        {
            var o = obj as MastodonApiConfig;
            if (o == null) return false;
            return Equals(InstanceBaseUrl, o.InstanceBaseUrl) &&
                Equals(ClientId, o.ClientId) &&
                Equals(ClietnSecret, o.ClietnSecret);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(InstanceBaseUrl, ClientId, ClietnSecret);
        }
    }
}
