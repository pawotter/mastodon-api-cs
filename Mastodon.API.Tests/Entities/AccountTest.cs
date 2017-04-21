using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class AccountTest
    {
        static string getJsonString()
        {
            var assembly = typeof(AccountTest).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_account.json");
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
                new Uri("/headers/original/missing.png"),
                new Uri("/headers/original/missing.png")
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
