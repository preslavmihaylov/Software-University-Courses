using System;

class Rectangle : BasicShape
{
    public Rectangle(double width, double height) : base(width, height)
    {
    }

    public override double CalculatePerimeter()
    {
        return this.Width * 2 + this.Height * 2;
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }
}