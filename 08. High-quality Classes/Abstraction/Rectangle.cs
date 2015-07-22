namespace Abstraction
{
    using System.Text;

   public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
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
                Validator.ObjectValidator.CheckIfNull(value, "Width must not be null");
                
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
                Validator.ObjectValidator.CheckIfNull(value, "Height must not be null");

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendLine();
            result.AppendFormat("Width: {0:f2}", this.Width);
            result.AppendLine();
            result.AppendFormat("Height: {0:f2}", this.Height);
            result.AppendLine();
            result.AppendFormat("Perimeter: {0:f2}", this.CalculatePerimeter());
            result.AppendLine();
            result.AppendFormat("Surface: {0:f2}", this.CalculateSurface());
            result.AppendLine();

            return result.ToString();
        }
    }
}
