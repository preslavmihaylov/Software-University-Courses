using System;

namespace CohesionAndCoupling
{
    class Geometry2D
    {
        public static double CalcDistance2D(double x1, double x2, double y1, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
    }
}
