using System;
namespace Mastodon.API
{
    public class MastodonApiConfig
    {
        public Uri InstanceUrl { get; }
        public string AccessToken { get; }

        public MastodonApiConfig(Uri instanceUrl, string accessToken)
        {
            InstanceUrl = instanceUrl;
            AccessToken = accessToken;
        }

        public override string ToString()
        {
            return string.Format("[MastodonApiConfig: InstanceBaseUrl={0}, AccessToken={1}]", InstanceUrl, AccessToken);
        }

        public override bool Equals(object obj)
        {
            var o = obj as MastodonApiConfig;
            if (o == null) return false;
            return Equals(InstanceUrl, o.InstanceUrl) &&
                Equals(AccessToken, o.AccessToken);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(InstanceUrl);
        }
    }
}
