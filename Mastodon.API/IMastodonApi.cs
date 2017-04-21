using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mastodon.API
{
    public interface IMastodonApi
    {
        Task<Account> GetAccount(string id, CancellationToken? token = null);
    }
}
