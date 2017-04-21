using System;
namespace Mastodon.API
{
    public class MastodonApiConfig
    {
        public Uri InstanceBaseUrl { get; }
        public string AccessToken { get; }

        public MastodonApiConfig(Uri instanceBaseUrl, string accessToken)
        {
            InstanceBaseUrl = instanceBaseUrl;
            AccessToken = accessToken;
        }

        public override string ToString()
        {
            return string.Format("[MastodonApiConfig: InstanceBaseUrl={0}, AccessToken={1}]", InstanceBaseUrl, AccessToken);
        }

        public override bool Equals(object obj)
        {
            var o = obj as MastodonApiConfig;
            if (o == null) return false;
            return Equals(InstanceBaseUrl, o.InstanceBaseUrl) &&
                Equals(AccessToken, o.AccessToken);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(InstanceBaseUrl);
        }
    }
}
