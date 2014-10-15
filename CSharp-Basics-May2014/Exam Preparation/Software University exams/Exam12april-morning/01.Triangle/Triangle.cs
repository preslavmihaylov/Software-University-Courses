using System;
class Triangle
{
    static void Main()
    {
        int coordinateAx = int.Parse(Console.ReadLine());
        int coordinateAy = int.Parse(Console.ReadLine());

        int coordinateBx = int.Parse(Console.ReadLine());
        int coordinateBy = int.Parse(Console.ReadLine());

        int coordinateCx = int.Parse(Console.ReadLine());
        int coordinateCy = int.Parse(Console.ReadLine());

        double distanceAB = Math.Sqrt(Math.Pow((coordinateBx - coordinateAx), 2) + Math.Pow((coordinateBy - coordinateAy), 2));
        double distanceBC = Math.Sqrt(Math.Pow((coordinateCx - coordinateBx), 2) + Math.Pow((coordinateCy - coordinateBy), 2));
        double distanceAC = Math.Sqrt(Math.Pow((coordinateAx - coordinateCx), 2) + Math.Pow((coordinateAy - coordinateCy), 2));

        if (distanceAB + distanceBC > distanceAC && distanceAB + distanceAC > distanceBC &&
            distanceBC + distanceAC > distanceAB)
        {
            Console.WriteLine("Yes");
            double halfPerimeter = (distanceAB + distanceBC + distanceAC) / 2;
            double areaOfTriangle = Math.Sqrt(halfPerimeter * (halfPerimeter - distanceAB) * (halfPerimeter - distanceBC) *
                (halfPerimeter - distanceAC));
            Console.WriteLine("{0:0.00}", areaOfTriangle);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:0.00}", distanceAB);
        }
    }
}
