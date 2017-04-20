using System;
namespace Mastodon.API
{
    /// <summary>
    /// Notification.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#notification
    /// </summary>
    public class Notification
    {
        public string Id { get; }
        public string Type { get; }
        public string CreatedAt { get; }
        public Account Account { get; }
        public Status? Status { get; }

        public Notification(string id, string type, string createdAt, Account account, Status? status)
        {
            Id = id;
            Type = type;
            CreatedAt = createdAt;
            Account = account;
            Status = status;
        }
    }
}
