using System.Text.RegularExpressions;

namespace FRBSiteMigrator
{
    public static class StringExtensions
    {

        public static string StripProtocol(this string str)
        {
            return Regex.Replace(str, @"^(https?|ftp)://", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string ToFilenameSafeString(this string str)
        {
            var trimmed = str.Trim('/');
            return Regex.Replace(trimmed, @"[^a-z0-9._-]", "-", RegexOptions.IgnoreCase);
        }

        public static string MakeLinkRelative(this string url)
        {
            return Regex.Replace(url, @"^https?://[^/]+", string.Empty, RegexOptions.IgnoreCase);
        }
    }
}
