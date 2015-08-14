namespace RotatingMatrix
{
    public class Coordinates
    {
        private int row;
        private int col;

        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            internal set
            {
                Validator.NumberValidator.CheckIfPositiveNumber(value, "Row value must be positive.");

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            internal set
            {
                Validator.NumberValidator.CheckIfPositiveNumber(value, "Col value must be positive.");

                this.col = value;
            }
        }
    }
}
