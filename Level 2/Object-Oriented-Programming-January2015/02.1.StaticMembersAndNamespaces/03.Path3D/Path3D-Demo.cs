using System;
using Geometry;

class Path3DDemo
{
    static void Main(string[] args)
    {
        Path3D path = new Path3D("../../Path.txt");
        Console.WriteLine(path.ToString());
        path.addPoint(new Point3D(50, 10, 12));
        path.addPoint(new Point3D(7, 9, 12.5));
        Console.WriteLine(path.ToString());

        path.saveChanges("../../Path.txt");
    }
}
