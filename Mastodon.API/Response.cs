using System.Net.Http;
namespace Mastodon.API
{
    public class Response<T>
    {
        public T Resource { get; }
        public HttpResponseMessage Message { get; }
        public Link? Link { get; }

        public Response(T resource, HttpResponseMessage message)
        {
            Resource = resource;
            Message = message;
            Link = API.Link.Create(message.Headers);
        }

        public override string ToString()
        {
            return string.Format("[Response: Resource={0}, Message={1}]", Resource, Message);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Response<T>;
            if (o == null) return false;
            return Equals(Resource, o.Resource) &&
                Equals(Message, o.Message);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Resource, Message);
        }
    }
}
