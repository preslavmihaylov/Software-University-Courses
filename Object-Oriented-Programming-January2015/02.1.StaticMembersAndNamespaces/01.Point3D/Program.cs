using System;
using Geometry;

class Program
{
    static void Main()
    {
        Point3D test = new Point3D(2, 2, 5);
        Console.WriteLine(test.ToString());
        Console.WriteLine(Point3D.StartingPoint.ToString());
    }
}
