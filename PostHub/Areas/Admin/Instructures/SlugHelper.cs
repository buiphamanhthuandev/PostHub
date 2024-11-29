using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace PostHub.Areas.Admin.Instructures
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }
            title = Remove(title);

            var slug = Regex.Replace(title, @"[^a-zA-Z0-9\s-]", "");

            slug = slug.ToLowerInvariant();

            slug = Regex.Replace(slug, @"\s+", "-");

            return slug;
        }
        private static string Remove(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var ch in normalizedString)
            {
                if(CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(ch);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
