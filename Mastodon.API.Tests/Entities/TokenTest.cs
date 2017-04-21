using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class TokenTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_token.json");
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
            var actual = JsonConvert.DeserializeObject<Token>(jsonString);
            var expected = new Token("aiueo", "bearer", "read", "1492791762");
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
