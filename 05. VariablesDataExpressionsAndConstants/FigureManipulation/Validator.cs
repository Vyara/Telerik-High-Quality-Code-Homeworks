namespace FigureManipulation
{
    using System;

    public static class Validator
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
