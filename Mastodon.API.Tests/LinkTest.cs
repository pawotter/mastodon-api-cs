using System;
using NUnit.Framework;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Mastodon.API.Tests
{
    [TestFixture]
    public class LinkTest
    {
        [Test]
        public void createNextAndPrevLinkTest()
        {
            var str = TestUtils.GetResource("Mastodon.API.Tests.Resources.next_and_prev_link");
            var link = Link.CreateLinkFromHeaderLinkValue(str);
            Assert.NotNull(link);
            Assert.AreEqual(1860868, link.Value.MaxId);
            Assert.AreEqual(1874433, link.Value.SinceId);
        }

        [Test]
        public void createNextLinkTest()
        {
            var str = TestUtils.GetResource("Mastodon.API.Tests.Resources.next_link");
            var link = Link.CreateLinkFromHeaderLinkValue(str);
            Assert.NotNull(link);
            Assert.AreEqual(1860868, link.Value.MaxId);
            Assert.Null(link.Value.SinceId);
        }

        [Test]
        public void createPrevLinkTest()
        {
            var str = TestUtils.GetResource("Mastodon.API.Tests.Resources.prev_link");
            var link = Link.CreateLinkFromHeaderLinkValue(str);
            Assert.NotNull(link);
            Assert.Null(link.Value.MaxId);
            Assert.AreEqual(1874433, link.Value.SinceId);
        }

        [Test]
        public void createLinkTestWithEmptyString()
        {
            var str = "";
            var link = Link.CreateLinkFromHeaderLinkValue(str);
            Assert.Null(link);
        }
    }
}
