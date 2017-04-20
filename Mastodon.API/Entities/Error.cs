using System;
namespace Mastodon.API
{
    /// <summary>
    /// Error.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#error
    /// </summary>
    public class Error
    {
        public string Description { get; }
        public Error(string error)
        {
            Description = error;
        }
    }
}
