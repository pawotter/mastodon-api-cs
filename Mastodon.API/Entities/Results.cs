using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mastodon.API
{
    /// <summary>
    /// Results.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#results
    /// </summary>
    public class Results
    {
        [JsonProperty(PropertyName = "accounts")]
        public IList<Account> Accounts { get; set; }
        [JsonProperty(PropertyName = "statuses")]
        public IList<Status> Statuses { get; set; }
        [JsonProperty(PropertyName = "hashtags")]
        public IList<string> Hashtags { get; set; }

        public Results(IList<Account> accounts, IList<Status> statuses, IList<string> hashtags)
        {
            Accounts = accounts;
            Statuses = statuses;
            Hashtags = hashtags;
        }

        public override string ToString()
        {
            return string.Format("[Results: Accounts={0}, Statuses={1}, Hashtags={2}]", Accounts, Statuses, Hashtags);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Results;
            if (o == null) return false;
            return
                Object.SequenceEqual(Accounts, o.Accounts) &&
                      Object.SequenceEqual(Statuses, o.Statuses) &&
                      Object.SequenceEqual(Hashtags, o.Hashtags);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Accounts, Statuses, Hashtags);
        }
    }
}
