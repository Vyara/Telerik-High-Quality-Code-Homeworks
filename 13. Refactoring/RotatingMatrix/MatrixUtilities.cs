namespace RotatingMatrix
{
    using System;

    public static class MatrixUtilities
    {
        private const int NumberOfDirections = 8;
        private static readonly int[] ChangeInRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] ChangeInCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static int UpdateUpperOrLeftPosition(int position)
        {
            int updatedPosition;
            if (position > 0)
            {
                updatedPosition = position - 1;
            }
            else
            {
                updatedPosition = position;
            }

            return updatedPosition;
        }

        public static int UpdateLowerOrRightPosition(int position, int count)
        {
            int updatedPosition;

            if (position < (count - 1))
            {
                updatedPosition = position + 1;
            }
            else
            {
                updatedPosition = position;
            }

            return updatedPosition;
        }

        public static bool NeighbouringCellsAreVisited(this int[,] matrix, int matrixRow, int matrixCol)
        {
            int matrixRowsCount = matrix.GetLength(0);
            int matrixColCount = matrix.GetLength(1);

            int upperRow = UpdateUpperOrLeftPosition(matrixRow);
            int lowerRow = UpdateLowerOrRightPosition(matrixRow, matrixRowsCount);
            int leftCol = UpdateUpperOrLeftPosition(matrixCol);
            int rightCol = UpdateLowerOrRightPosition(matrixCol, matrixColCount);

            for (int row = upperRow; row <= lowerRow; row++)
            {
                for (int col = leftCol; col <= rightCol; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Coordinates GetStartingPosition(this int[,] matrix)
        {
            int matrixRowsCount = matrix.GetLength(0);
            int matrixColCount = matrix.GetLength(1);

            for (int row = 0; row < matrixRowsCount; row++)
            {
                for (int col = 0; col < matrixColCount; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Coordinates(row, col);
                    }
                }
            }

            return null;
        }

        public static bool IsValidNextDirection(this int[,] matrix, int row, int col)
        {
            if (!matrix.IsInRange(row, col))
            {
                return false;
            }

            if (matrix[row, col] != 0)
            {
                return false;
            }

            return true;
        }

        public static RotationDirection GetNextDirection(this int[,] matrix, RotationDirection direction, int row, int col)
        {
            for (int i = 0; i < NumberOfDirections; i++)
            {
                var currentDirection = (RotationDirection)(((int)direction + i) % NumberOfDirections);
                int currentRow = row + GetChangeInRow(currentDirection);
                int currentCol = col + GetChangeInCol(currentDirection);
                if (matrix.IsValidNextDirection(currentRow, currentCol))
                {
                    return currentDirection;
                }
            }

            throw new InvalidOperationException("All cells are visited.");
        }

        public static int GetChangeInRow(RotationDirection direction)
        {
            return ChangeInRow[(int)direction];
        }

        public static int GetChangeInCol(RotationDirection direction)
        {
            return ChangeInCol[(int)direction];
        }

        private static bool IsInRange(this int[,] matrix, int row, int col)
        {
            int matrixRowsCount = matrix.GetLength(0);
            var matrixColCount = matrix.GetLength(1);

            bool rowIsInRange = row >= 0 && row < matrixRowsCount;
            bool colIsInRange = col >= 0 && col < matrixColCount;

            return rowIsInRange && colIsInRange;
        }
    }
}
