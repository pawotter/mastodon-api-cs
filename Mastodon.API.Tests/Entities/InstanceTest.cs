using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class InstanceTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_instance.json");
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
            var actual = JsonConvert.DeserializeObject<Instance>(jsonString);
            var expected = new Instance("friends.nico", "friends.nico", "test", "test@test.nico");
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
