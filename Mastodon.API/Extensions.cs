namespace Mastodon.API
{
    public static class Object
    {
        public static int GetHashCode(object o)
        {
            return o == null ? 0 : o.GetHashCode();
        }
    }
}
