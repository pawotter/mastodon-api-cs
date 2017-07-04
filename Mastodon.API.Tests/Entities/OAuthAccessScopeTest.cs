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
            Assert.AreEqual("read", OAuthAccessScope.Of(OAtuhAccessScopeType.Read).Value);
            Assert.AreEqual("write", OAuthAccessScope.Of(OAtuhAccessScopeType.Write).Value);
            Assert.AreEqual("follow", OAuthAccessScope.Of(OAtuhAccessScopeType.Follow).Value);
            Assert.AreEqual("read", OAuthAccessScope.Of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Read).Value);
            Assert.AreEqual("read write", OAuthAccessScope.Of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Write).Value);
            Assert.AreEqual("read write follow", OAuthAccessScope.Of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Write, OAtuhAccessScopeType.Follow).Value);
            Assert.AreEqual("read write follow", OAuthAccessScope.Of(OAtuhAccessScopeType.Read, OAtuhAccessScopeType.Write, OAtuhAccessScopeType.Follow, OAtuhAccessScopeType.Read).Value);
        }
    }
}
