using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class StatusTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = EntityTestUtils.getJsonString("Mastodon.API.Tests.Resources.get_status.json");
            var actual = JsonConvert.DeserializeObject<Status>(jsonString);
            var expected = new Status(
                "622216",
                "tag:friends.nico,2017-04-21:objectId=622216:objectType=Status",
                new Uri("https://friends.nico/@gomi_ningen/622216"),
                new Account(
                    "29",
                    "gomi_ningen",
                    "gomi_ningen",
                    "ゴミ人間 ✅",
                    false,
                    "2017-04-19T06:38:32.390Z",
                    165,
                    115,
                    204,
                    "<a href=\"https://twitter.com/gomi_ningen\" rel=\"nofollow noopener\" target=\"_blank\"><span class=\"invisible\">https://</span><span class=\"\">twitter.com/gomi_ningen</span><span class=\"invisible\"></span></a> 木組みの街のSIerラビットハウス社で住み込みバイトしているエンジニアです。",
                    new Uri("https://friends.nico/@gomi_ningen"),
                    // fixme
                    null, //new Uri("https://d2zoeobnny43zx.cloudfront.net/accounts/avatars/000/000/029/original/bc840deef1c57f8f.png?1492587071"),
                    null, //new Uri("https://d2zoeobnny43zx.cloudfront.net/accounts/avatars/000/000/029/original/bc840deef1c57f8f.png?1492587071"),
                    new Uri("/headers/original/missing.png"),
                    new Uri("/headers/original/missing.png")
                ),
                null,
                null,
                null,
                "<p>アプリから投稿テスト</p>",
                "2017-04-21T11:47:31.293Z",
                0,
                2,
                false,
                false,
                null,
                "",
                StatusVisibility.Unlisted,
                new List<Attachment>(),
                new List<Mention>(),
                new List<Tag>(),
                new Application(
                    "Amaroq",
                    new Uri("https://appsto.re/us/OfFxib.i"))
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
