using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mastodon.API
{
    public class OAuthAccessScope
    {
        IEnumerable<OAtuhAccessScopeType> types;
        public OAuthAccessScope(params OAtuhAccessScopeType[] types)
        {
            this.types = types.ToList();
        }

        internal string Value
        {
            get
            {
                var ts = types.Distinct().Select(x => value(x));
                return string.Join(" ", ts);
            }
        }

        static string value(OAtuhAccessScopeType type)
        {
            switch (type)
            {
                case OAtuhAccessScopeType.Read: return "read";
                case OAtuhAccessScopeType.Write: return "write";
                case OAtuhAccessScopeType.Follow: return "follow";
            }
            return "";
        }
    }

    public enum OAtuhAccessScopeType
    {
        Read,
        Write,
        Follow
    }
}
