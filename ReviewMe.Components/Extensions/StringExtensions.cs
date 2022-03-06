using System.Globalization;
using System.Text;

namespace ReviewMe.Components.Extensions
{
    public static class StringExtensions
    {
        public static string WithoutDiacritics(this string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                    .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                 UnicodeCategory.NonSpacingMark)
            ).Normalize(NormalizationForm.FormC);
        }
    }
}