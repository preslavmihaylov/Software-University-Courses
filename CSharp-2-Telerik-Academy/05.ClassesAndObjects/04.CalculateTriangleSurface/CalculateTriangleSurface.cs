using System;
class CalculateTriangleSurface
{
    static void Main()
    {
        Console.Write("Input a triangle side: ");
        double side = double.Parse(Console.ReadLine());
        
        Console.Write("Input a triangle altitude: ");
        double altitude = double.Parse(Console.ReadLine());
        
        sideAltutudeCalculation(side, altitude);
        
        Console.Write("Input first triangle side: ");
        double firstSide = double.Parse(Console.ReadLine());
        Console.Write("Input second triangle side: ");
        double secondSide = double.Parse(Console.ReadLine());
        Console.Write("Input third triangle side: ");
        double thirdSide = double.Parse(Console.ReadLine());
        
        threeSidesCalculation(firstSide, secondSide, thirdSide);

        Console.Write("Input first triangle side: ");
        firstSide = double.Parse(Console.ReadLine());
        Console.Write("Input second triangle side: ");
        secondSide = double.Parse(Console.ReadLine());
        Console.Write("Input the angle between them: ");
        double angle = double.Parse(Console.ReadLine());

        twoSidesAngleCalculation(firstSide, secondSide, angle);
    }

    private static void sideAltutudeCalculation(double side, double altitude)
    {
        double surface = (double)(side * altitude) / 2;
        Console.WriteLine("Surface of Triangle calculated with side and altitude: {0}", surface);
    }

    private static void threeSidesCalculation(double first, double second, double third)
    {
        double halfPerimeter = (double)(first + second + third) / 2;
        double surface = Math.Sqrt(halfPerimeter * (halfPerimeter - first) * (halfPerimeter - second) * (halfPerimeter - third));

        Console.WriteLine("Surface of Triangle calculated with three sides: {0}", surface);
    }

    private static void twoSidesAngleCalculation(double first, double second, double angle)
    {
        double surface = (double)(first * second * Math.Sin((angle * Math.PI)/180)) / 2;
        Console.WriteLine("Surface of Triangle calculated with two sides with included angle: {0}", surface);
    }
}
