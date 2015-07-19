namespace Problem_2
{
    using System;
    using System.Linq;

    public class IncreasingAbsoluteDifferences
    {
        public static void Main()
        {
            int numberOfSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSequences; i++)
            {
                decimal[] currentSequence = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

                if (IsSequenceIncreasing(AbsoluteDifferences(currentSequence)))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }

       public static decimal[] AbsoluteDifferences(decimal[] sequence)
        {
            var absoliteDifferences = new decimal[sequence.Length - 1];

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                absoliteDifferences[i] = Math.Abs(sequence[i] - sequence[i + 1]);
            }

            return absoliteDifferences;
        }

       public static bool IsSequenceIncreasing(decimal[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (i + 1 < sequence.Length)
                {
                    decimal abs = Math.Abs(sequence[i] - sequence[i + 1]);

                    if (sequence[i] > sequence[i + 1])
                    {
                        return false;
                    }
                    else if (abs != 0M && abs != 1M)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
