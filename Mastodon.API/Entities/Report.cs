using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Mastodon.API
{
    /// <summary>
    /// Report.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#report
    /// </summary>
    public class Report
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; }
        [JsonProperty(PropertyName = "action_taken")]
        public bool ActionTaken { get; }

        public Report(string id, bool actionTaken)
        {
            Id = id;
            ActionTaken = actionTaken;
        }

        public override string ToString()
        {
            return string.Format("[Report: Id={0}, ActionTaken={1}]", Id, ActionTaken);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Report;
            if (o == null) return false;
            return Equals(Id, o.Id) && Equals(ActionTaken, o.ActionTaken);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, ActionTaken);
        }
    }
}
