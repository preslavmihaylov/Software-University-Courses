using System;

class Triangle : BasicShape
{
    // the sides of the triangle. Side a is already used by the width of the inherited class.
    private double b;
    private double c;

    public double B
    {
        get
        {
            return this.b;
        }
        set
        {
            this.b = value;
        }
    }

    public double C
    {
        get
        {
            return this.c;
        }
        set
        {
            this.c = value;
        }
    }

    public Triangle(double a ,double b, double c, double height) : base(a, height)
    {
        this.B = b;
        this.C = c;
    }

    public override double CalculatePerimeter()
    {
        return this.Width + this.B + this.C;
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height / 2;
    }
}
