using System.Globalization;

namespace UniverseFramework.Core.Extensions
{
    public static class Tools
    {
        /// <summary>
        /// To clear characters ((Ğ-G) - (Ü-U) - (Ş-S) - (ı-i) - (İ-I) - (Ö-O) - (Ç - C))
        /// </summary>
        public static string ClearCharacters(this string Text)
        {
            string strReturn = Text.Trim();

            strReturn = strReturn.Replace("ğ", "g");
            strReturn = strReturn.Replace("Ğ", "G");
            strReturn = strReturn.Replace("ü", "u");
            strReturn = strReturn.Replace("Ü", "U");
            strReturn = strReturn.Replace("ş", "s");
            strReturn = strReturn.Replace("Ş", "S");
            strReturn = strReturn.Replace("ı", "i");
            strReturn = strReturn.Replace("İ", "I");
            strReturn = strReturn.Replace("ö", "o");
            strReturn = strReturn.Replace("Ö", "O");
            strReturn = strReturn.Replace("ç", "c");
            strReturn = strReturn.Replace("Ç", "C");
            strReturn = strReturn.Trim();
            strReturn = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
            strReturn = strReturn.Trim();

            return strReturn;
        }

        /// <summary>
        /// To upper initials
        /// </summary>
        public static string ToCamel(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
    }
}
