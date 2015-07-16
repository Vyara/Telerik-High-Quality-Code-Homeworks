namespace Problem3
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class ConsoleApplication2
    {
       public static void Main()
        {
            List<decimal> numbers = new List<decimal>();
            decimal number;
            BigInteger product = 1;
            BigInteger allProducts = 1;
            BigInteger allOtherProduct = 1;

            while (decimal.TryParse(Console.ReadLine(), out number))
            {
                numbers.Add(number);
            }

            if (numbers.Count <= 10)
            {
                CheckIfEven(0, numbers.Count, numbers, product, allProducts);
            }
            else
            {
                CheckIfEven(0, 10, numbers, product, allProducts);

                CheckIfEven(10, numbers.Count, numbers, product, allProducts);
            }

            PrintResult(numbers, allProducts, allOtherProduct);
        }

        public static void CheckIfEven(int startingIndex, int endingIndex, List<decimal> numbers, BigInteger product, BigInteger allProducts)
        {
            for (int i = startingIndex; i < endingIndex; i++)
            {
                if (i % 2 == 0)
                {
                    ModifyIfInEvenPosition(i, numbers, product);

                    CalculateProduct(product, allProducts);
                }
            }
        }

        public static void ModifyIfInEvenPosition(int index, List<decimal> numbers, BigInteger product)
        {
            string evenNumber = numbers[index].ToString();
            if (numbers[index] == 0)
            {
                product *= 1;
            }
            else
            {
                ModifyIfDigitIsNotZero(evenNumber, product);
            }
        }

        public static void ModifyIfDigitIsNotZero(string evenNumber, BigInteger product)
        {
            for (int j = 0; j < evenNumber.Length; j++)
            {
                if (evenNumber[j] != '0' && char.IsDigit(evenNumber[j]))
                {
                    product *= evenNumber[j] - '0';
                }
            }
        }

        public static void CalculateProduct(BigInteger product, BigInteger allProducts)
        {
            allProducts *= product;
            product = 1;
        }

        public static void PrintResult(List<decimal> numbers, BigInteger allProducts, BigInteger allOtherProduct)
        {
            if (numbers.Count <= 10)
            {
                Console.WriteLine(allProducts);
            }
            else
            {
                Console.WriteLine(allProducts);
                Console.WriteLine(allOtherProduct);
            }
        }
    }
}
