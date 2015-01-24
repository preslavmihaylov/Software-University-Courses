using System;
using Geometry;

class DistanceCalculatorDemo
{
    static void Main()
    {
        Point3D start = Point3D.StartingPoint;
        Point3D end = new Point3D(12, 7, 5);
        Console.WriteLine(Math.Round(DistanceCalculator.CalculateDistance(start, end), 2));
    }
}
