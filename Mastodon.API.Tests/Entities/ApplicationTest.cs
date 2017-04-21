using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ApplicationTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_application.json");
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
            var actual = JsonConvert.DeserializeObject<Application>(jsonString);
            var expected = new Application("Amaroq", new Uri("https://appsto.re/us/OfFxib.i"));
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
