namespace Abstraction
{
    using System;
    using System.Text;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

           private set
            {
                Validator.NumberValidator.CheckIfPositiveNumber(value, "Radius must be a positive number.");
                Validator.ObjectValidator.CheckIfNull(value, "Radius must not be null");

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendLine();
            result.AppendFormat("Radius: {0:f2}", this.Radius);
            result.AppendLine();
            result.AppendFormat("Perimeter: {0:f2}", this.CalculatePerimeter());
            result.AppendLine();
            result.AppendFormat("Surface: {0:f2}", this.CalculateSurface());
            result.AppendLine();

            return result.ToString();
        }
    }
}
