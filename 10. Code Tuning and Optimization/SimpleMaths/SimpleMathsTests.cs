namespace SimpleMaths
{
    using System;
    using System.Diagnostics;

    public class SimpleMathsTests
    {
        private const int LoopingCount = 5000000;

        internal static void Main()
        {
            Console.WriteLine("Int");
            var x1 = 0;
            ExecuteMathTests(x1);

            Console.WriteLine("Long");
            long x2 = 0;
            ExecuteMathTests(x2);

            Console.WriteLine("float");
            float x3 = 0;
            ExecuteMathTests(x3);

            Console.WriteLine("double");
            double x4 = 0;
            ExecuteMathTests(x4);

            Console.WriteLine("decimal");
            decimal x5 = 0;
            ExecuteMathTests(x5);
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

            Console.Write("Add: ");
            DisplayExecutionTime(() =>
            {
                a = a + 0;
                for (var i = 0; i < LoopingCount; i++)
                {
                    a = a + 1;
                }
            });

            Console.Write("Subtract: ");
            DisplayExecutionTime(() =>
            {
                a = a + 5000000;
                for (var i = 0; i < LoopingCount; i++)
                {
                    a = a - 1;
                }
            });

            Console.Write("Increment: ");
            DisplayExecutionTime(() =>
            {
                a = a + 0;
                for (var i = 0; i < LoopingCount; i++)
                {
                    a++;
                }
            });

            Console.Write("Multiply: ");
            DisplayExecutionTime(() =>
            {
                a = a + 1;
                for (var i = 0; i < LoopingCount; i++)
                {
                    a = a * 1;
                }
            });

            Console.Write("Divide: ");
            DisplayExecutionTime(() =>
            {
                a = a + 1;
                for (var i = 0; i < LoopingCount; i++)
                {
                    a = a / 1;
                }
            });
        }
    }
}
