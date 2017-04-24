using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class RelationshipTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_relationship.json");
            var actual = JsonConvert.DeserializeObject<Relationship>(jsonString);
            var expected = new Relationship("29", true, true, true, true, true);
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
