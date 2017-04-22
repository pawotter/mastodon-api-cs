using System;
using NUnit.Framework;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class OAuthAccessScopeTest
    {
        [Test]
        public void ValueTest()
        {
            Assert.AreEqual("read", OAuthAccessScope.of(OAtuhAccessScopeType.Read).Value);
            Assert.AreEqual("write", OAuthAccessScope.of(OAtuhAccessScopeType.Write).Value);
            Assert.AreEqual("follow", OAuthAccessScope.of(OAtuhAccessScopeType.Follow).Value);
            Assert.AreEqual("read", OAuthAccessScope.of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Read).Value);
            Assert.AreEqual("read write", OAuthAccessScope.of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Write).Value);
            Assert.AreEqual("read write follow", OAuthAccessScope.of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Write, OAtuhAccessScopeType.Follow).Value);
            Assert.AreEqual("read write follow", OAuthAccessScope.of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Write, OAtuhAccessScopeType.Follow, OAtuhAccessScopeType.Read).Value);
        }
    }
}
