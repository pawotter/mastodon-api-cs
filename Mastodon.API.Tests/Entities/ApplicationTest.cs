using NUnit.Framework;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ApplicationTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = EntityTestUtils.getJsonString("Mastodon.API.Tests.Resources.get_application.json");
            var actual = JsonConvert.DeserializeObject<Application>(jsonString);
            var expected = new Application("Amaroq", new Uri("https://appsto.re/us/OfFxib.i"));
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
