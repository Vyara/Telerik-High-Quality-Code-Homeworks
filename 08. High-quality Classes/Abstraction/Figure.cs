namespace Abstraction
{
    using System.Text;

   public abstract class Figure
    {
        protected Figure()
        {
        }

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            var result = new StringBuilder();
            
            result.AppendLine(this.GetType().Name);

            return base.ToString();
        }
    }
}
