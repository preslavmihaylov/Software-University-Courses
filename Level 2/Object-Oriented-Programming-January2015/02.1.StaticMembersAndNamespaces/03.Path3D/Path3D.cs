using System;
using Geometry;
using System.Collections.Generic;

class Path3D
{
    private List<Point3D> path = new List<Point3D>();

    public List<Point3D> Path
    {
        get
        {
            return this.path;
        }
    }

    public Path3D(string inputPath)
    {
        this.getInputPath(inputPath);
    }

    private void getInputPath(string inputPath)
    {
        string[] input = Storage.readInput(inputPath);

        for (int index = 0; index < input.Length; index++)
        {
            string[] coordinates = input[index].Split(new char[] {' ', ',', '{', '}'}, StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length != 3)
            {
                break;
            }
            double x = double.Parse(coordinates[0]);
            double y = double.Parse(coordinates[1]);
            double z = double.Parse(coordinates[2]);

            this.path.Add(new Point3D(x, y, z));
        }
    }

    public void saveChanges(string output)
    {
        Storage.writeOutput(this.path, output);
    }

    public void addPoint(Point3D destination)
    {
        this.path.Add(destination);
    }

    public override string ToString()
    {
        return String.Join(" -- ", this.Path);
    }
}
