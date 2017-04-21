using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mastodon.API
{
    public interface IMastodonApi
    {
        /// <summary>
        /// Gets the OAuth token.
        /// DO NOT USE IN APP.
        /// </summary>
        /// <returns>OAuth token.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="token">Token.</param>
        Task<Token> GetOAuthToken(string username, string password, OAuthAccessScope scope, CancellationToken? token = null);

        Task<Account> GetAccount(string id, CancellationToken? token = null);
    }
}
