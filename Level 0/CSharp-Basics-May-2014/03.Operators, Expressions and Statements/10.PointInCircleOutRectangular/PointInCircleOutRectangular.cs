using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem 10.	Point Inside a Circle & Outside of a Rectangle
//Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5)
//and out of the rectangle R(top=1, left=-1, width=6, height=2). 

struct Circle
{
    // position x and position y (0, 0)
    public double x;
    public double y;
    public double radius;
}

struct Rectangular
{
    public double top;
    public double left;
    public double width;
    public double height;
}
class PointInCircleOutRectangular
{
    static void Main()
    {
        Circle circle = new Circle();
        circle.x = 1;
        circle.y = 1;
        circle.radius = 1.5;

        Rectangular rect = new Rectangular();
        rect.top = 1;
        rect.left = -1;
        rect.width = 6;
        rect.height = 2;

        bool inCircle = false;
        bool inRect = false;

        double inputX = double.Parse(Console.ReadLine());
        double inputY = double.Parse(Console.ReadLine());



        if (Math.Pow((inputX - circle.x), 2) + Math.Pow((inputY - circle.y), 2) <= Math.Pow(circle.radius, 2))
        {
            inCircle = true;
        }

        if ((inputX >= rect.left && inputX <= rect.left + rect.width) &&
            (inputY <= rect.top && inputY >= rect.top - rect.height))
        {
            inRect = true;
        }

        if (inCircle == true && inRect == false)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }

    }
}
