using System;
using System.Collections.Generic;
namespace Mastodon.API
{
    /// <summary>
    /// Context.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#card
    /// </summary>
    public class Context
    {
        public IList<Status> Ancestors { get; }
        public IList<Status> Descendants { get; }
    }
}
