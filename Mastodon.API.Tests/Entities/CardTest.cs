using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class CardTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_card.json");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        [Test]
        public void DeserializeTest()
        {
            var jsonString = getJsonString();
            var actual = JsonConvert.DeserializeObject<Card>(jsonString);
            var expected = new Card(
                new Uri("http://seiga.nicovideo.jp/comic/20782"),
                "ご注文はうさぎですか？ / Koi",
                "喫茶ラビットハウスにやってきたココア。 実は、そこが彼女が住み込むことになっていた喫茶店で…。 すべて…",
                new Uri("https://d2zoeobnny43zx.cloudfront.net/preview_cards/images/000/001/769/original/ogp_alternative.jpg?1492773335")
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
