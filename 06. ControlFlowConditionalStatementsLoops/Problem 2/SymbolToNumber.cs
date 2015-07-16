namespace Problem2
{
    using System;

    public class SymbolToNumber
    {
        public static void Main()
        {
            int secret = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            EncodeText(secret, text);
        }

        public static void EncodeText(int secret, string text)
        {
            int count = 0;
            double character = 0;
            while (text[count] != '@')
            {
                if (char.IsLetter(text[count]))
                {
                    character = (text[count] * secret) + 1000;
                }
                else if (char.IsDigit(text[count]))
                {
                    character = (text[count] + secret) + 500;
                }
                else
                {
                    character = text[count] - secret;
                }

                if (count % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", character / 100);
                    character = 0;
                }
                else
                {
                    Console.WriteLine(character * 100);
                    character = 0;
                }

                count++;
            }
        }
    }
}
