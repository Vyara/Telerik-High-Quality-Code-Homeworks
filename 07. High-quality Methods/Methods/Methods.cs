namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, FormatOptions.Round);
            PrintAsNumber(0.75, FormatOptions.Percent);
            PrintAsNumber(2.30, FormatOptions.AlignRight);

            double firstX = 3;
            double secondX = 3;
            double firstY = -1;
            double secondY = 2.5;

            bool isHorizontal = firstY == secondY;
            bool isVertical = firstX == secondX;

            Console.WriteLine(CalcDistanceBetweenTwoPoints(firstX, secondX, firstY, secondY));
            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17), "Sofia");

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03), "Vidin", "gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string ConvertDigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentException("Invalid number!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Elements array cannot be null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Elements array must not be empty.");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void PrintAsNumber(object number, FormatOptions format)
        {
            switch (format)
            {
                case FormatOptions.Round: Console.WriteLine("{0:f2}", number);
                    break;
                case FormatOptions.Percent: Console.WriteLine("{0:p0}", number);
                    break;
                case FormatOptions.AlignRight: Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid format option input.");
            }
        }

        public static double CalcDistanceBetweenTwoPoints(double firstX, double secondX, double firstY, double secondY)
        {
            double firstPointSquaredSubstraction = (secondX - firstX) * (secondX - firstX);
            double secondPointSquaredSubstraction = (secondY - firstY) * (secondY - firstY);

            double distance = Math.Sqrt(firstPointSquaredSubstraction + secondPointSquaredSubstraction);
            return distance;
        }
    }
}
