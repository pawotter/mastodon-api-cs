using System;
namespace Mastodon.API
{
    /// <summary>
    /// Report.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#report
    /// </summary>
    public class Report
    {
        public string Id { get; }
        public string ActionTaken { get; }

        public Report(string id, string actionTaken)
        {
            Id = id;
            ActionTaken = actionTaken;
        }
    }
}
