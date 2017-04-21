using System;
namespace Mastodon.API
{
    /// <summary>
    /// Notification.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#notification
    /// </summary>
    public class Notification
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string CreatedAt { get; set; }
        public Account Account { get; set; }
        public Status Status { get; set; }

        public Notification(string id, string type, string createdAt, Account account, Status status)
        {
            Id = id;
            Type = type;
            CreatedAt = createdAt;
            Account = account;
            Status = status;
        }
    }
}
