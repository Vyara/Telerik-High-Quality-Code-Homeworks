namespace FigureManipulation
{
    using System;

    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
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
                Validator.CheckIfPositiveNumber(value, "Width must be a positive number.");

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
                Validator.CheckIfPositiveNumber(value, "Height must be a positive number.");

                this.height = value;
            }
        }

        public static Figure GetRotatedFigure(
            Figure figure, double angleOfRotation)
        {
            double absoluteCosinusRotation = Math.Abs(Math.Cos(angleOfRotation));
            double absoluteSinusRotation = Math.Abs(Math.Sin(angleOfRotation));
            double rotatedWidth = (absoluteCosinusRotation * figure.Width) + (absoluteSinusRotation * figure.Height);
            double rotatedHeight = (absoluteSinusRotation * figure.Width) + (absoluteCosinusRotation * figure.Height);

            return new Figure(rotatedWidth, rotatedHeight);
        }
    }
}
