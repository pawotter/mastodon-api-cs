using NUnit.Framework;
using System;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class InstanceTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_instance.json");
            var actual = JsonConvert.DeserializeObject<Instance>(jsonString);
            var expected = new Instance("friends.nico", "friends.nico", "test", "test@test.nico");
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
