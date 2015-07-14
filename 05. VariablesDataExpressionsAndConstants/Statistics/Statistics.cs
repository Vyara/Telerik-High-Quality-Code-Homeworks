namespace Statistics
{
    using System;

    public class Statistics
    {
        public static void Main()
        {
            var numbers = new double[]
            {
                2, 4, 1, -2
            };

            var count = numbers.Length;

            Print(numbers, count);
        }

        public static void Print(double[] values, int count)
        {
            var maxValue = CalculateMaxValue(values, count);
            PrintValue(maxValue, "maximal");

            var minValue = CalculateMinValue(values, count);
            PrintValue(minValue, "minimal");

            var averageValue = CalculateAverageValue(values, count);
            PrintValue(averageValue, "average");

            var sumValue = CalculateSumValue(values, count);
            PrintValue(sumValue, "sum");
        }

        private static void PrintValue(double value, string valueType)
        {
            Console.WriteLine("The {0} value is: {1}", valueType, value);
        }

        private static double CalculateMinValue(double[] values, int count)
        {
            double minValue = 0;

            for (int i = 0; i < count; i++)
            {
                if (values[i] < minValue)
                {
                    minValue = values[i];
                }
            }

            return minValue;
        }

        private static double CalculateMaxValue(double[] values, int count)
        {
            double maxValue = 0;

            for (int i = 0; i < count; i++)
            {
                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                }
            }

            return maxValue;
        }

        private static double CalculateSumValue(double[] values, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += values[i];
            }

            return sum;
        }

        private static double CalculateAverageValue(double[] values, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += values[i];
            }

            double average = sum / values.Length;

            return average;
        }
    }
}
