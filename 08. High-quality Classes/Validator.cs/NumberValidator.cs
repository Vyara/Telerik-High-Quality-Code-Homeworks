namespace Validator
{
    using System;

    public class NumberValidator
    {
        public static void CheckIfPositiveNumber(double number, string message = null)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
