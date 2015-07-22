namespace CohesionAndCoupling
{
    using System;

    public static class DistanceCalculationUtils
    {
        public static double CalcDistance2D(double firstX, double secondX, double firstY, double secondY)
        {
            double firstPointSquaredSubstraction = (secondX - firstX) * (secondX - firstX);
            double secondPointSquaredSubstraction = (secondY - firstY) * (secondY - firstY);

            double distance = Math.Sqrt(firstPointSquaredSubstraction + secondPointSquaredSubstraction);
            return distance;
        }

        public static double CalcDistance3D(double firstX, double secondX, double firstY, double secondY, double firstZ, double secondZ)
        {
            double firstPointSquaredSubstraction = (secondX - firstX) * (secondX - firstX);
            double secondPointSquaredSubstraction = (secondY - firstY) * (secondY - firstY);
            double thirdPointSquaredSubstraction = (secondZ - firstZ) * (secondZ - firstZ);

            double distance = Math.Sqrt(firstPointSquaredSubstraction + secondPointSquaredSubstraction + thirdPointSquaredSubstraction);
            return distance;
        }
    }
}
