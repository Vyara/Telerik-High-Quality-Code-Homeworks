namespace Validator
{
    using System;

    public class ObjectValidator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
