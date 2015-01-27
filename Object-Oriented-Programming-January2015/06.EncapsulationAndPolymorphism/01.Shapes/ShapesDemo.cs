using System;

class ShapesDemo
{
    static void Main()
    {
        IShape[] shapes = new IShape[3];
        shapes[0] = new Circle(5);
        shapes[1] = new Triangle(5, 2, 6, 4);
        shapes[2] = new Rectangle(2, 4.5);

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.GetType().Name);
            Console.WriteLine("Area: " + shape.CalculateArea());
            Console.WriteLine("Perimeter: " + shape.CalculatePerimeter());
            Console.WriteLine();
        }
    }
}
