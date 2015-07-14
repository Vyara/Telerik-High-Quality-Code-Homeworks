namespace StringExtentions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides extention methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Generates a hash code for the provided <paramref name="input"/>.
        /// </summary>
        /// <param name="input">A string to be hashed.</param>
        /// <returns>A hexadecimal representation of the <paramref name="input"/>.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if <paramref name="input"/> can be considered to be a true value, based on a group of string values considered to be true.
        /// </summary>
        /// <param name="input">A string to be checked</param>
        /// <returns>True if the string contains a specific true value and false otherwise.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts a string value to <seealso cref="System.Int16"/> format.
        /// </summary>
        /// <param name="input">A string to be parsed to <seealso cref="System.Int16"/></param>
        /// <returns>The input string in <seealso cref="System.Int16"/> if parcing was successful, 0 otherwise.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts a string value to <seealso cref="System.Int32"/> format.
        /// </summary>
        /// <param name="input">A string to be parsed to <seealso cref="System.Int32"/></param>
        /// <returns>The input string in <seealso cref="System.Int32"/> if parcing was successful, 0 otherwise.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts a string value to <seealso cref="System.Int64"/> format.
        /// </summary>
        /// <param name="input">A string to be parsed to <seealso cref="System.Int64"/></param>
        /// <returns>The input string in <seealso cref="System.Int64"/> if parcing was successful, 0 otherwise.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts a string value to <seealso cref="System.DateTime"/> format.
        /// </summary>
        /// <param name="input">A string to be parsed to <seealso cref="System.DateTime"/></param>
        /// <returns>The input string in <seealso cref="System.DateTime"/> if parcing was successful, or the default value of <seealso cref="System.DateTime"/> otherwise.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes thr first letter of a string.
        /// </summary>
        /// <param name="input">A string to be capitalized.</param>
        /// <returns>The original input if it was null or empty, and the capitalized string if otherwise.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Searches for and extracts a string from in between two other provided strings.
        /// </summary>
        /// <param name="input">The target string</param>
        /// <param name="startString">The string from which the seaarch should start.</param>
        /// <param name="endString">The string to which the search should end.</param>
        /// <param name="startFrom">Provides the starting position for the search.</param>
        /// <returns>The extracted target string. Should the string not exist within the provided parameters, it returns an empty string</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts a string input constructed of cyrillic letters to a new string containing their latin letters representation.
        /// </summary>
        /// <param name="input">An input string constructed of cyrillic letters.</param>
        /// <returns>The string value with its cyrillic letters converted to latin letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts a string input constructed of latin letters to a new string containing their cyrillic letters representation.
        /// </summary>
        /// <param name="input">An input string constructed of latin letters.</param>
        /// <returns>The string value with its latin letters converted to cyrillic letters.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Removes invalid symbols from an username(if any).
        /// </summary>
        /// <param name="input">A string input, from which the invalid symbols(if any) would be removed.</param>
        /// <returns>A string value with the invalid symbols replaced.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Removes invalid symbols from a file name(if any).
        /// </summary>
        /// <param name="input">A string input, from which the invalid symbols(if any) would be removed.</param>
        /// <returns>A string value with the invalid symbols replaced.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Extracts the first given number of characters from a string.
        /// </summary>
        /// <param name="input">An input string value, from which the characters would be extracted.</param>
        /// <param name="charsCount">A number presenting the number of characters that should be exctracted and returned from the input string.</param>
        /// <returns>A substring from the input string containing the extracted characters.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Extracts and returns the file extetion from a file name.
        /// </summary>
        /// <param name="fileName">A string value containig the file name.</param>
        /// <returns>A string value containing the file extention, or an empty string value, if no such extention is found.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Extracts and returns the content type from a file extention.
        /// </summary>
        /// <param name="fileExtension">A string containing a file extention.</param>
        /// <returns>A string representing the content type of the file extention.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            //default content type value
            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a given string to a byte array.
        /// </summary>
        /// <param name="input">A string value to be converted.</param>
        /// <returns>A byte array, with every symbol of the input string converted to a byte value.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
