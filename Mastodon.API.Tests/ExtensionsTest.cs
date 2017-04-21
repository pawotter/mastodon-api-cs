using NUnit.Framework;
using System.Collections.Generic;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void AsQueryStringTest()
        {
            var ps = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("x1", "y1"),
                new KeyValuePair<string, object>("x2", "y2"),
                new KeyValuePair<string, object>("x3", "y3")
            };
            var expected = "?x1=y1&x2=y2&x3=y3";
            Assert.AreEqual(expected, ps.AsQueryString());
        }
    }
}
