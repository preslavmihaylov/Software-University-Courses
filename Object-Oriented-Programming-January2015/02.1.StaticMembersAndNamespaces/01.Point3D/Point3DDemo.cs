using System;
using Geometry;

class Point3DDemo
{
    static void Main()
    {
        Point3D test = new Point3D(2, 2, 5);
        Console.WriteLine(test.ToString());
        Console.WriteLine(Point3D.StartingPoint.ToString());
    }
}
