namespace RotatingMatrix
{
    using System.Text;

   public class Matrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;
        private int size;
        private int[,] matrixtemplate;

        public Matrix(int size)
        {
            this.Size = size;
            this.matrixtemplate = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                Validator.NumberValidator.CheckIfNumberIsInRange(value, MinSize, MaxSize, string.Format("Matrix size should be in range [{0}; {1}]", MinSize, MaxSize));

                this.size = value;
            }
        }

        public int[,] MatrixTemplate
        {
            get
            {
                return (int[,])this.matrixtemplate.Clone();
            }
        }

        public void RotatingWalkVisitCells()
        {
            Coordinates position = this.matrixtemplate.GetStartingPosition();
            RotationDirection direction = RotationDirection.DownAndRight;
            int rowChange = RotatingWalkUtils.GetChangeInRow(direction);
            int colChange = RotatingWalkUtils.GetChangeInCol(direction);
            int cellValue = 1;

            while (cellValue <= this.Size * this.Size)
            {
                this.matrixtemplate[position.Row, position.Col] = cellValue;

                if (!this.matrixtemplate.IsValidNextDirection(position.Row + rowChange, position.Col + colChange))
                {
                    bool neighboursAreFilled = false;

                    if (this.matrixtemplate.NeighbouringCellsAreVisited(position.Row, position.Col))
                    {
                        neighboursAreFilled = true;

                        position = this.matrixtemplate.GetStartingPosition();
                        if (position == null)
                        {
                            break;
                        }

                        direction = RotationDirection.DownAndRight;
                    }
                    else
                    {
                        direction = this.matrixtemplate.GetNextDirection(direction, position.Row, position.Col);
                    }

                    rowChange = RotatingWalkUtils.GetChangeInRow(direction);
                    colChange = RotatingWalkUtils.GetChangeInCol(direction);

                    if (neighboursAreFilled)
                    {
                        continue;
                    }
                }

                position.Row += rowChange;
                position.Col += colChange;
                cellValue += 1;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.matrixtemplate.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrixtemplate.GetLength(1); col++)
                {
                    result.AppendFormat("{0, -5}", this.matrixtemplate[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
