namespace Mastodon.API
{
    public static class Object
    {
        public static int GetHashCode(object o)
        {
            return o == null ? 0 : o.GetHashCode();
        }

        public static int GetHashCode(params object[] objects)
        {
            var hashCode = 0;
            foreach (object obj in objects)
            {
                hashCode = hashCode ^ GetHashCode(obj);
            }
            return hashCode;
        }
    }
}
