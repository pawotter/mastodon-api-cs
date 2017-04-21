using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class TagTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_tag.json");
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
            var actual = JsonConvert.DeserializeObject<Tag>(jsonString);
            var expected = new Tag("test1", new Uri("https://friends.nico/tags/test1"));
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
