using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class AttachmentTest
    {
        static string getJsonString()
        {
            var assembly = typeof(InstanceTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Mastodon.API.Tests.Resources.get_attachment.json");
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
            var actual = JsonConvert.DeserializeObject<Attachment>(jsonString);
            var expected = new Attachment(
                "39071",
                "image",
                new Uri("https://d2zoeobnny43zx.cloudfront.net/media_attachments/files/000/039/071/original/1a37136a4fe604b1.png?1492771668"),
                new Uri("https://d2zoeobnny43zx.cloudfront.net/media_attachments/files/000/039/071/original/1a37136a4fe604b1.png?1492771668"),
                new Uri("https://d2zoeobnny43zx.cloudfront.net/media_attachments/files/000/039/071/small/1a37136a4fe604b1.png?1492771668"),
                new Uri("https://friends.nico/media/NB4b8WwFtCxC2ynwZis")
            );
            Assert.AreEqual(expected, actual);
            actual.GetHashCode();
        }
    }
}
