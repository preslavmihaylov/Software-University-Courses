using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.WriteLine("Input radius:");
        double radius = double.Parse(Console.ReadLine());

        Console.WriteLine("Perimeter: {0:F2}", 2 * 3.14159 * radius);
        Console.WriteLine("Area: {0:F2}", radius * radius * 3.14159);
    }
}
