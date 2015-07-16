namespace Problem1
{
    using System;

    public class ABC
    {
        public static void Main()
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long thirdNumber = long.Parse(Console.ReadLine());

            decimal maxBC = Math.Max(secondNumber, thirdNumber);
            decimal minBC = Math.Min(secondNumber, thirdNumber);
            decimal max = Math.Max(firstNumber, maxBC);
            decimal min = Math.Min(firstNumber, minBC);
            double mean = (firstNumber + secondNumber + thirdNumber) / 3.0;

            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine("{0:F3}", mean);
        }
    }
}
