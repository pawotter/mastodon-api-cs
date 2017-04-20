using System;
namespace Mastodon.API
{
    /// <summary>
    /// Card.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#card
    /// </summary>
    public class Card
    {
        public string Url { get; }
        public string Title { get; }
        public string Description { get; }
        public string Image { get; }

        public Card(string url, string title, string description, string image)
        {
            Url = url;
            Title = title;
            Description = description;
            Image = image;
        }
    }
}
