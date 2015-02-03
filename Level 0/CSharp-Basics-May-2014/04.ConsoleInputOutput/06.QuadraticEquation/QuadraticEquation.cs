using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Input a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Input b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Input c:");
        double c = double.Parse(Console.ReadLine());
        
        double discriminant = (b * b) - (4 * a * c);

        if (discriminant == 0)
        {
            Console.WriteLine("x1 = x2 = {0}", -b / (2 * a));
        }
        else if (discriminant < 0)
        {
            Console.WriteLine("no real roots");
        }
        else
        {
            Console.Write("x1 = {0}; ", (-b - Math.Sqrt(discriminant)) / (2 * a));
            Console.WriteLine("x2 = {0}", (-b + Math.Sqrt(discriminant)) / (2 * a));
        }
    }
}
