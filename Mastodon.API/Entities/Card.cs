using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Card.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#card
    /// </summary>
    public class Card
    {
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "image")]
        public Uri Image { get; set; }

        internal Card() { }

        Card(Uri url, string title, string description, Uri image)
        {
            Url = url;
            Title = title;
            Description = description;
            Image = image;
        }

        public static Card Create(Uri url, string title, string description, Uri image)
        {
            return new Card(url, title, description, image);
        }


        public override string ToString()
        {
            return string.Format("[Card: Url={0}, Title={1}, Description={2}, Image={3}]", Url, Title, Description, Image);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Card;
            if (o == null) return false;
            return Equals(Url, o.Url) &&
                Equals(Title, o.Title) &&
                Equals(Description, o.Description) &&
                Equals(Image, o.Image);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Url, Title, Description, Image);
        }
    }
}
