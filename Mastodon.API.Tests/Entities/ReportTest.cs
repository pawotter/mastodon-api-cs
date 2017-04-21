using NUnit.Framework;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ReportTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_report.json");
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
            var actual = JsonConvert.DeserializeObject<Report>(jsonString);
            var expected = new Report("101", true);
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
