using System;
using System.IO;
using System.Reflection;

namespace Mastodon.API.Tests
{
    static class EntityTestUtils
    {
        internal static string getJsonString(string resourceName)
        {
            var assembly = typeof(AccountTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(resourceName);
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

    }
}
