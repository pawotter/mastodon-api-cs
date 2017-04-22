using NUnit.Framework;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class CardTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = EntityTestUtils.getJsonString("Mastodon.API.Tests.Resources.get_card.json");
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
