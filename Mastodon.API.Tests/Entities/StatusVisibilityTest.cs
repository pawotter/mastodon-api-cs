using System;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    struct StatusVisibilityTestStruct
    {
        [JsonProperty(PropertyName = "v")]
        public StatusVisibility V { get; set; }
    }

    [TestFixture]
    public class StatusVisibilityTest
    {
        [Test]
        public void Deserialize()
        {
            var vPrivate = JsonConvert.DeserializeObject<StatusVisibilityTestStruct>("{\"v\":\"private\"}");
            Assert.AreEqual(StatusVisibility.Private, vPrivate.V);
            var vPublic = JsonConvert.DeserializeObject<StatusVisibilityTestStruct>("{\"v\":\"public\"}");
            Assert.AreEqual(StatusVisibility.Public, vPublic.V);
            var vUnlisted = JsonConvert.DeserializeObject<StatusVisibilityTestStruct>("{\"v\":\"unlisted\"}");
            Assert.AreEqual(StatusVisibility.Unlisted, vUnlisted.V);
            var vDirect = JsonConvert.DeserializeObject<StatusVisibilityTestStruct>("{\"v\":\"direct\"}");
            Assert.AreEqual(StatusVisibility.Direct, vDirect.V);
        }
    }
}
