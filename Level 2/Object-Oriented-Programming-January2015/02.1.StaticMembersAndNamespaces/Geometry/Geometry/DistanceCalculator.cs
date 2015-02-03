using System;

namespace Geometry
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D start, Point3D end)
        {
            Point3D resultVector = new Point3D(end.X - start.X, end.Y - start.Y, end.Z - start.Z);

            return Math.Sqrt(Math.Pow(resultVector.X, 2) + Math.Pow(resultVector.Y, 2) + Math.Pow(resultVector.Z, 2));
        }
    }
}
