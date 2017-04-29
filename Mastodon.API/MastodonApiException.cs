using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Mastodon.API
{
    /// <summary>
    /// This exception indicates an error code from the MastodonAPI (i.e., 400, 404, 500, etc).
    /// It is up to the caller to catch these exceptions and take appropriate action within their application.
    /// </summary>
    public class MastodonApiException : Exception
    {
        /// <summary>
        /// The StatusCode returned from the Http call to the API
        /// </summary>
        public HttpStatusCode StatusCode { get; }
        /// <summary>
        /// Deserialized representation of the error message from the API
        /// </summary>
        public Error Error { get; set; }

        public MastodonApiException(HttpStatusCode statusCode, Error error)
        {
            StatusCode = statusCode;
            Error = error;
        }

        public MastodonApiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
