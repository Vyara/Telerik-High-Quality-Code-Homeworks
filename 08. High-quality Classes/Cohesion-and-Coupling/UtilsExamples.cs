namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));
            Console.WriteLine();

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));
            Console.WriteLine();

            Console.WriteLine("Distance in the 2D space = {0:f2}", DistanceCalculationUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", DistanceCalculationUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));
            Console.WriteLine();

            var parallelepiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine(parallelepiped.ToString());
        }
    }
}
