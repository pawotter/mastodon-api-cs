using System;
namespace Mastodon.API
{
    /// <summary>
    /// Attachment.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#attachment
    /// </summary>
    public struct Attachment
    {
        public string Id { get; }
        public string Type { get; }
        public string Url { get; }
        public string RemoteUrl { get; }
        public string PreviewUrl { get; }
        public string TextUrl { get; }

        public Attachment(string id, string type, string url, string remoteUrl, string previewUrl, string textUrl)
        {
            Id = id;
            Type = type;
            Url = url;
            RemoteUrl = remoteUrl;
            PreviewUrl = previewUrl;
            TextUrl = textUrl;
        }
    }
}
