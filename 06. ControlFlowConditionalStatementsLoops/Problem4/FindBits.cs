namespace Problem4
{
    using System;

    class FindBits
    {
        static void Main()
        {
            int S = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            string Sstring = Convert.ToString(S, 2).PadLeft(29, '0');
            int outerCount = 0;
            for (int i = 0; i < N; i++)
            {
                int innerCount = 0;
                long number = long.Parse(Console.ReadLine());
                string stringNumber = Convert.ToString(number, 2).PadLeft(29, '0');
                string Slast5 = "";
                string SlastReverse = "";

                for (int k = 0; k < 5; k++)
                {
                    Slast5 += Sstring[Sstring.Length - 1 - k];
                }

                for (int l = 0; l < Slast5.Length; l++)
                {
                    SlastReverse += Slast5[Slast5.Length - 1 - l];
                }

                for (int j = 0; j < stringNumber.Length; j++)
                {
                    if (j + 1 < stringNumber.Length && j + 2 < stringNumber.Length && j + 3 < stringNumber.Length && j + 4 < stringNumber.Length)
                    {
                        if (stringNumber[j] == SlastReverse[0] && stringNumber[j + 1] == SlastReverse[1] && stringNumber[j + 2] == SlastReverse[2] && stringNumber[j + 3] == SlastReverse[3] && stringNumber[j + 4] == SlastReverse[4])
                        {
                            innerCount++;
                        }
                    }
                }
                outerCount += innerCount;
            }
            Console.WriteLine(outerCount);
        }
    }
}