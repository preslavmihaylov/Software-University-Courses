using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 7.	Point in a Circle
//Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2). 
struct Object
{
    // position x and position y (0, 0)
    public double x;
    public double y;
    public double radius;
}
class PointInCircle
{
    static void Main()
    {
        Object circle = new Object();
        circle.x = 0;
        circle.y = 0;
        circle.radius = 2;

        double inputX = double.Parse(Console.ReadLine());
        double inputY = double.Parse(Console.ReadLine());

        if (Math.Pow((inputX - circle.x), 2) + Math.Pow((inputY - circle.y), 2) <= Math.Pow(circle.radius, 2))
        {
            Console.WriteLine("The point is inside the circle");
        }
        else
        {
            Console.WriteLine("The point is outside of the circle");
        }
    
    }
}