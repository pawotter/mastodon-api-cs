using NUnit.Framework;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class TokenTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_token.json");
            var actual = JsonConvert.DeserializeObject<Token>(jsonString);
            var expected = Token.create("aiueo", "bearer", "read", "1492791762");
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
