using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class MentionTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_mention.json");
            var actual = JsonConvert.DeserializeObject<Mention>(jsonString);
            var expected = Mention.create(
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
