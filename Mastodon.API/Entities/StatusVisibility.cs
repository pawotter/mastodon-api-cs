using System;
namespace Mastodon.API
{
    public enum StatusVisibility
    {
        Direct,
        Private,
        Unlisted,
        Public
    }

    public static class StatusVisibilities
    {
        public static string Value(this StatusVisibility visibility)
        {
            switch (visibility)
            {
                case StatusVisibility.Direct: return "direct";
                case StatusVisibility.Private: return "private";
                case StatusVisibility.Public: return "public";
                case StatusVisibility.Unlisted: return "unlisted";
            }
            return "";
        }
    }
}
