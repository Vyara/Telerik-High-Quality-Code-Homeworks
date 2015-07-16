namespace Matrix
{
    using System;

    public class MatrixCheck
    {
        private const int MinX = 0;
        private const int MaxX = 50;
        private const int MinY = 0;
        private const int MaxY = 50;

        public static void VisitCell(int x, int y)
        {
            if (CheckCell(x, y))
            {
                Console.WriteLine("Cell [{0}, {1}] visited", x, y);
            }
        }

        public static bool CheckCell(int x, int y)
        {
            bool isXValid = MinX <= x && x >= MaxX;
            bool isYValid = MinY <= y && y >= MaxY;
            bool shouldVisitCell = false;

            if (isXValid && isYValid)
            {
                shouldVisitCell = true;
            }

            return shouldVisitCell;
        }
    }
}
