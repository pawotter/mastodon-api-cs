using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Notification.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#notification
    /// </summary>
    public class Notification
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty(PropertyName = "account")]
        public Account Account { get; set; }
        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }

        internal Notification() { }

        Notification(string id, string type, string createdAt, Account account, Status status)
        {
            Id = id;
            Type = type;
            CreatedAt = createdAt;
            Account = account;
            Status = status;
        }

        public static Notification create(string id, string type, string createdAt, Account account, Status status)
        {
            return new Notification(id, type, createdAt, account, status);
        }

        public override string ToString()
        {
            return string.Format("[Notification: Id={0}, Type={1}, CreatedAt={2}, Account={3}, Status={4}]", Id, Type, CreatedAt, Account, Status);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Notification;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(Type, o.Type) &&
                Equals(CreatedAt, o.CreatedAt) &&
                Equals(Account, o.Account) &&
                Equals(Status, o.Status);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, Type, CreatedAt, Account, Status);
        }
    }
}
