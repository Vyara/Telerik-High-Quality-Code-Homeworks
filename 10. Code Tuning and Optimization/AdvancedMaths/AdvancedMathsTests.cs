namespace AdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathsTests
    {
       private const int LoopingCount = 5000000;

        internal static void Main()
        {
            Console.WriteLine("float");
            float x1 = 0;
            ExecuteMathTests(x1);

            Console.WriteLine("double");
            double x2 = 0;
            ExecuteMathTests(x2);

            Console.WriteLine("decimal");
            decimal x3 = 0;
            ExecuteMathTests(x3);
        }

        private static void DisplayExecutionTime(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void ExecuteMathTests(dynamic a)
        {
            a = a + 1;

            Console.Write("Square Root: ");
            DisplayExecutionTime(() =>
            {
                for (var i = 0; i < LoopingCount; i++)
                {
                    Math.Sqrt((double)a);
                }
            });

            Console.Write("Natural algorithm: ");
            DisplayExecutionTime(() =>
            {
                for (var i = 0; i < LoopingCount; i++)
                {
                    Math.Log((double)a);
                }
            });

            Console.Write("Sinus: ");
            DisplayExecutionTime(() =>
            {
                for (var i = 0; i < LoopingCount; i++)
                {
                    Math.Sin((double)a);
                }
            });
        }
    }
}
