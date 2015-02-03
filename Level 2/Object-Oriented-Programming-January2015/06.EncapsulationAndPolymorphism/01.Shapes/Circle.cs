using System;

class Circle : IShape
{
    private double radius;

    public double Radius
    {
        get
        {
            return this.radius;
        }
        set
        {
            this.radius = value;
        }
    }

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    public double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }
}
