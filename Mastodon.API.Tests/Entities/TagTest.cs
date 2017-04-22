using NUnit.Framework;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class TagTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = EntityTestUtils.getJsonString("Mastodon.API.Tests.Resources.get_tag.json");
            var actual = JsonConvert.DeserializeObject<Tag>(jsonString);
            var expected = new Tag("test1", new Uri("https://friends.nico/tags/test1"));
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
