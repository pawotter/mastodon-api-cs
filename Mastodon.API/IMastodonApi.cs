using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mastodon.API
{
    public interface IMastodonApi
    {
        /// <summary>
        /// Return an OAuth token.
        /// DO NOT USE IN APP.
        /// </summary>
        /// <returns>OAuth token.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="token">Token.</param>
        Task<Token> GetOAuthToken(string username, string password, OAuthAccessScope scope, CancellationToken? token = null);


        /// <summary>
        /// Returns an Account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Account> GetAccount(string id, CancellationToken? token = null);

        /// <summary>
        /// Returns the authenticated user's Account.
        /// </summary>
        /// <returns>The current account.</returns>
        /// <param name="token">Token.</param>
        Task<Account> GetCurrentAccount(CancellationToken? token = null);

        // todo: max_id and since_id are usually get from the Link header.
        /// <summary>
        /// Returns an array of Accounts.
        /// Getting an account's followers.
        /// </summary>
        /// <returns>The followers.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="maxId">Get a list of followers with ID less than or equal this value</param>
        /// <param name="sinceId">Get a list of followers with ID greater than this value</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>
        /// <param name="token">Token.</param>
        Task<Account[]> GetFollowers(string id, string maxId = null, string sinceId = null, int? limit = null, CancellationToken? token = null);

    }
}
