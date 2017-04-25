using System;
using System.IO;
using System.Reflection;

namespace Mastodon.API.Tests
{
    static class TestUtils
    {
        internal static string GetResource(string resourceName)
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
