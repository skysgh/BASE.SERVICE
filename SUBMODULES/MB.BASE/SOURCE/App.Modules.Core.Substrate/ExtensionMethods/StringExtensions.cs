using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    /// Extensions to Strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Easier way to see if a string contains a given string 
        /// in a case insensitive manner.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool Contains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            if (text == null || value == null) return false;
            return text.Contains(value, stringComparison);
        }


        /// <summary>
        /// Pluralise nouns
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string SimplePluralise(this string text)
        {
            if (text.LastOrDefault(' ') == 'y')
            {
                return $"{text.Substring(0, text.Length - 1)}ies";
            }
            return text + 's';
        }
    }
}