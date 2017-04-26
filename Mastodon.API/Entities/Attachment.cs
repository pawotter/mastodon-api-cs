using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Attachment.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#attachment
    /// </summary>
    public class Attachment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }
        [JsonProperty(PropertyName = "remote_url")]
        public Uri RemoteUrl { get; set; }
        [JsonProperty(PropertyName = "preview_url")]
        public Uri PreviewUrl { get; set; }
        [JsonProperty(PropertyName = "text_url")]
        public Uri TextUrl { get; set; }

        internal Attachment() { }

        Attachment(string id, string type, Uri url, Uri remoteUrl, Uri previewUrl, Uri textUrl)
        {
            Id = id;
            Type = type;
            Url = url;
            RemoteUrl = remoteUrl;
            PreviewUrl = previewUrl;
            TextUrl = textUrl;
        }

        public static Attachment create(string id, string type, Uri url, Uri remoteUrl, Uri previewUrl, Uri textUrl)
        {
            return new Attachment(id, type, url, remoteUrl, previewUrl, textUrl);
        }

        public override string ToString()
        {
            return string.Format("[Attachment: Id={0}, Type={1}, Url={2}, RemoteUrl={3}, PreviewUrl={4}, TextUrl={5}]", Id, Type, Url, RemoteUrl, PreviewUrl, TextUrl);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Attachment;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(Type, o.Type) &&
                Equals(Url, o.Url) &&
                Equals(RemoteUrl, o.RemoteUrl) &&
                Equals(PreviewUrl, o.PreviewUrl) &&
                Equals(TextUrl, o.TextUrl);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, Type, Url, RemoteUrl, PreviewUrl, TextUrl);
        }
    }
}

