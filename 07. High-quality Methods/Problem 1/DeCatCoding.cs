namespace Problem_1
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class DeCatCoding
    {
        public static void Main()
        {
            var code = GenerateCode();
            var alphabet = GenerateEnglishAlphabetCollection();

            string[] letter_numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Decode(letter_numbers, code, alphabet);
        }

        public static Dictionary<int, char> GenerateEnglishAlphabetCollection()
        {
            var alphabet = new Dictionary<int, char>();
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)(97 + i);
            }

            return alphabet;
        }

        public static Dictionary<char, int> GenerateCode()
        {
            var code = new Dictionary<char, int>();
            for (int i = 0; i < 21; i++)
            {
                code[(char)(97 + i)] = i;
            }

            return code;
        }

        public static void Decode(string[] text, Dictionary<char, int> code, Dictionary<int, char> alphabet)
        {
            for (int i = 0; i < text.Length; i++)
            {
                var result = CalculateResult(text, code, i);

                if (result < 26)
                {
                    Console.WriteLine(alphabet[(int)result]);
                }
                else
                {
                    var number = DecodeIfResultIsLongerThanAlphabet(result, alphabet);

                    number.Reverse();

                    PrintDecodedMessage(text, number, i);
                }
            }
        }

        private static BigInteger CalculateResult(string[] text, Dictionary<char, int> code, int i)
        {
            int count = text[i].Length - 1;
            int index = 0;
            BigInteger result = 0;
            while (count >= 0)
            {
                result += (BigInteger)(code[text[i][count]] * BigInteger.Pow(21, index));
                count--;
                index++;
            }

            return result;
        }

        private static List<char> DecodeIfResultIsLongerThanAlphabet(BigInteger result, Dictionary<int, char> alphabet)
        {
            var number = new List<char>();
            while (result > 0)
            {
                if (result % 26 >= 26)
                {
                    var newResult = result % 26;
                    while (newResult > 26)
                    {
                        number.Add(alphabet[(int)(newResult % 26)]);
                        newResult /= 26;
                    }

                    result += newResult;
                }

                number.Add(alphabet[(int)(result % 26)]);
                result /= 26;
            }

            return number;
        }

        private static void PrintDecodedMessage(string[] text, List<char> number, int i)
        {
            for (int j = 0; j < number.Count; j++)
            {
                Console.Write(number[j]);
            }

            if (i != text.Length - 1)
            {
                Console.Write(" ");
            }
        }
    }
}
