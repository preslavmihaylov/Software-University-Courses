using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 9.	Trapezoids
//Write an expression that calculates trapezoid's area by given sides a and b and height h. 

class Trapezoids
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double area = (a + b) * h / 2;
        Console.WriteLine(area);
        
    }
}
