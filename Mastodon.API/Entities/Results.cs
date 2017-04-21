using System;
using System.Collections;
using System.Collections.Generic;

namespace Mastodon.API
{
    /// <summary>
    /// Results.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#results
    /// </summary>
    public class Results
    {
        public IList<Account> Accounts { get; set; }
        public IList<Status> Statuses { get; set; }
        public IList<string> Hashtags { get; set; }

        public Results(IList<Account> accounts, IList<Status> statuses, IList<string> hashtags)
        {
            Accounts = accounts;
            Statuses = statuses;
            Hashtags = hashtags;
        }
    }
}
