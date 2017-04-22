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
            var ps = new Dictionary<string, object>
            {
                {"x1", "y1"},
                {"x2", "y2"},
                {"x3", "y3"}
            };
            var expected = "?x1=y1&x2=y2&x3=y3";
            Assert.AreEqual(expected, ps.AsQueryString());
        }
    }
}
