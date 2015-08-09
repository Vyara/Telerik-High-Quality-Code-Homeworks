namespace Validator
{
    using System;

    public class StringValidator
    {
        public static void CheckIfStringIsNullOrWhiteSpace(string str, string message = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
