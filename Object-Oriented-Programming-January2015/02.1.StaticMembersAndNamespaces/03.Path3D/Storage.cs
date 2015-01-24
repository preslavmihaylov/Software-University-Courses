using System;
using System.IO;
using System.Collections.Generic;
using Geometry;

static class Storage
{
    public static string[] readInput(string path)
    {
        StreamReader reader = new StreamReader(path);
        string[] input = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        reader.Close();
        return input;
    }

    public static void writeOutput(List<Point3D> output, string path) 
    {
        StreamWriter writer = new StreamWriter(path);

        foreach (Point3D point in output)
        {
            writer.WriteLine(point.ToString());
        }

        writer.Close();
    }
}
