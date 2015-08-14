namespace RotatingMatrix
{
    internal class MatrixGenerator
    {
        internal static void Main()
        {
            Matrix matrix = new Matrix(6);
            matrix.RotatingWalkVisitCells();
            System.Console.WriteLine(matrix);
        }
    }
}
