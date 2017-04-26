using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class MastodonAppTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_mastodon_app.json");
            var actual = JsonConvert.DeserializeObject<MastodonApp>(jsonString);
            var expected = MastodonApp.create(
                "0",
                "client_id",
                "client_secret",
                new Uri("urn:ietf:wg:oauth:2.0:oob")
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
