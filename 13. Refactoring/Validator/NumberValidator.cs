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

        public static void CheckIfNumberIsInRange(int number, int min, int max, string message = null)
        {
            if (min > number || number > max)
            {
                throw new IndexOutOfRangeException(message);
            }
        }
    }
}