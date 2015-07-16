namespace ControlFlow
{
    using System;

    public class Loop
    {
        public static void Main()
        {
            int[] numbers = { 2, 4, -1, 6, 4, 10, 5, -2, 0, 9, 100, 104 };

            FindValue(numbers);
        }

        public static void FindValue(int[] array, int expectedValue = 100, int divider = 10)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);

                if ((i % divider == 0) && (array[i] == expectedValue))
                {
                    Console.WriteLine("Value Found");
                    break;
                }
            }
        }
    }
}
