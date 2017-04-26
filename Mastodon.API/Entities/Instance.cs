using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Instance.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#instance
    /// </summary>
    public class Instance
    {
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        internal Instance() { }

        Instance(string uri, string title, string description, string email)
        {
            Uri = uri;
            Title = title;
            Description = description;
            Email = email;
        }

        public static Instance create(string uri, string title, string description, string email)
        {
            return new Instance(uri, title, description, email);
        }

        public override string ToString()
        {
            return string.Format("[Instance: Uri={0}, Title={1}, Description={2}, Email={3}]", Uri, Title, Description, Email);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Instance;
            if (o == null) return false;
            return Equals(Uri, o.Uri) &&
                Equals(Title, o.Title) &&
                Equals(Description, o.Description) &&
                Equals(Email, o.Email);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Uri) ^
                         Object.GetHashCode(Title) ^
                         Object.GetHashCode(Description) ^
                         Object.GetHashCode(Email);
        }
    }
}
