using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_account.json");
            var actual = JsonConvert.DeserializeObject<Account>(jsonString);
            var expected = new Account(
                "29",
                "gomi_ningen",
                "gomi_ningen",
                "ゴミ人間 ✅",
                false,
                "2017-04-19T06:38:32.390Z",
                147,
                105,
                165,
                "<a href=\"https://twitter.com/gomi_ningen\" rel=\"nofollow noopener\" target=\"_blank\"><span class=\"invisible\">https://</span><span class=\"\">twitter.com/gomi_ningen</span><span class=\"invisible\"></span></a> 木組みの街のSIerラビットハウス社で住み込みバイトしているエンジニアです。",
                new Uri("https://friends.nico/@gomi_ningen"),
                null,
                null,
                new Uri("/headers/original/missing.png", UriKind.Relative),
                new Uri("/headers/original/missing.png", UriKind.Relative)
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
