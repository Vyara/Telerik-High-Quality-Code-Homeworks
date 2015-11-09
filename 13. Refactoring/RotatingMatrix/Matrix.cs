namespace RotatingMatrix
{
    using System.Text;

   public class Matrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;
        private int size;
        private readonly int[,] matrixtemplate;

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
                Validator.NumberValidator.CheckIfNumberIsInRange(value, MinSize, MaxSize, string.Format(format: "Matrix size should be in range [{0}; {1}]", arg0: MinSize, arg1: MaxSize));

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
            int rowChange = MatrixUtilities.GetChangeInRow(direction);
            int colChange = MatrixUtilities.GetChangeInCol(direction);
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

                    rowChange = MatrixUtilities.GetChangeInRow(direction);
                    colChange = MatrixUtilities.GetChangeInCol(direction);

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
            var result = new StringBuilder();

            for (int row = 0; row < this.matrixtemplate.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrixtemplate.GetLength(1); col++)
                {
                    result.AppendFormat(format: "{0, -5}", arg0: this.matrixtemplate[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
