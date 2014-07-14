using System;
using System.Collections.Generic;

class PerimeterAndAreaPolygon
{
    static void Main()
    {
        int countOfInputs = int.Parse(Console.ReadLine());
        Polygon polygon = new Polygon();
        polygon.points = new List<Point>();

        for (int index = 0; index < countOfInputs; index++)
        {
            string[] input = Console.ReadLine().Split();

            Point point = new Point();
            point.X = Convert.ToInt32(Convert.ToString(input[0]));
            point.Y = Convert.ToInt32(Convert.ToString(input[1]));

            polygon.points.Add(point);
        }

        double polygonPerimeter = 0;
        double polygonArea = 0;

        for (int index = 0; index < polygon.points.Count; index++)
        {
            int distanceX;
            int distanceY;
            if (index == polygon.points.Count - 1)
            {
                // calculating the distance between the first and the last point
                distanceX = Math.Abs(polygon.points[0].X - polygon.points[polygon.points.Count - 1].X);
                distanceY = Math.Abs(polygon.points[0].Y - polygon.points[polygon.points.Count - 1].Y);
                polygonArea += polygon.points[0].X * polygon.points[polygon.points.Count - 1].Y -
                    polygon.points[0].Y * polygon.points[polygon.points.Count - 1].X;
            }
            else
            {
                distanceX = Math.Abs(polygon.points[index].X - polygon.points[index + 1].X);
                distanceY = Math.Abs(polygon.points[index].Y - polygon.points[index + 1].Y);
                polygonArea += polygon.points[index].X * polygon.points[index + 1].Y -
                    polygon.points[index].Y * polygon.points[index + 1].X;
            }
            
            polygonPerimeter += Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
        }

        Console.WriteLine("Perimeter: {0:0.00}", polygonPerimeter);
        polygonArea = Math.Abs(polygonArea / 2);
        Console.WriteLine("Area: {0:0.00}", polygonArea);

    }
}
