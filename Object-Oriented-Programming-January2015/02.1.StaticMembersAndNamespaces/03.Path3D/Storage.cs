using System;
using System.IO;
using System.Collections.Generic;
using Geometry;

class Storage
{
    private StreamReader reader = new StreamReader("../../Path.txt");
    private StreamWriter writer;
    private string[] input;

    public string[] Input 
    {
        get {
            return this.input;
        }    
    }

    public Storage()
    {
        input = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    }

    public void writeOutput(List<Point3D> output) 
    {
        reader.Close();
        writer = new StreamWriter("../../Path.txt");

        foreach (Point3D point in output)
        {
            writer.WriteLine(point.ToString());
        }

        writer.Close();
    }
}
