using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Mastodon.API
{
    public class Token
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        internal Token() { }

        Token(string accessToken, string tokenType, string scope, string createdAt)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            Scope = scope;
            CreatedAt = createdAt;
        }

        public static Token Create(string accessToken, string tokenType, string scope, string createdAt)
        {
            return new Token(accessToken, tokenType, scope, createdAt);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Token;
            if (o == null) return false;
            return Equals(AccessToken, o.AccessToken) &&
                Equals(TokenType, o.TokenType) &&
                Equals(Scope, o.Scope) &&
                Equals(CreatedAt, o.CreatedAt);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(AccessToken, TokenType, Scope, CreatedAt);
        }

        public override string ToString()
        {
            return string.Format("[Token: AccessToken={0}, TokenType={1}, Scope={2}, CreatedAt={3}]", AccessToken, TokenType, Scope, CreatedAt);
        }
    }
}
