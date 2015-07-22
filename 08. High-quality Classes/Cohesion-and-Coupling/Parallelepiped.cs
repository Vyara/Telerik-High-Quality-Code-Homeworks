namespace CohesionAndCoupling
{
    using System.Text;

   public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                Validator.NumberValidator.CheckIfPositiveNumber(value, "Width must be a positive number.");
                Validator.ObjectValidator.CheckIfNull(value, "Width must not be null.");

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                Validator.NumberValidator.CheckIfPositiveNumber(value, "Height must be a positive number.");
                Validator.ObjectValidator.CheckIfNull(value, "Height must not be null.");

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                Validator.NumberValidator.CheckIfPositiveNumber(value, "Depth must be a positive number.");
                Validator.ObjectValidator.CheckIfNull(value, "Depth must not be null.");

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = DistanceCalculationUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = DistanceCalculationUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = DistanceCalculationUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = DistanceCalculationUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.GetType().Name);
            result.AppendFormat("Volume = {0:f2}", this.CalcVolume());
            result.AppendLine();
            result.AppendFormat("Diagonal XYZ = {0:f2}", this.CalcDiagonalXYZ());
            result.AppendLine();
            result.AppendFormat("Diagonal XY = {0:f2}", this.CalcDiagonalXY());
            result.AppendLine();
            result.AppendFormat("Diagonal XZ = {0:f2}", this.CalcDiagonalXZ());
            result.AppendLine();
            result.AppendFormat("Diagonal YZ = {0:f2}", this.CalcDiagonalYZ());
            result.AppendLine();

            return result.ToString();
        }
    }
}
