using NUnit.Framework;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ErrorTest
    {
        [Test]
        public void DeserializeTest()
        {
            var jsonString = EntityTestUtils.getJsonString("Mastodon.API.Tests.Resources.get_error.json");
            var actual = JsonConvert.DeserializeObject<Error>(jsonString);
            var expected = new Error("Record not found");
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
