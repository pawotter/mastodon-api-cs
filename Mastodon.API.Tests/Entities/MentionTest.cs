using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class MentionTest
    {
        static string getJsonString()
        {
            var assembly = typeof(AccountTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_mention.json");
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
            var actual = JsonConvert.DeserializeObject<Mention>(jsonString);
            var expected = new Mention(
                new Uri("https://friends.nico/@gomi_ningen"),
                "gomi_ningen",
                "gomi_ningen",
                "29"
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
