using System;

public abstract class BasicShape : IShape
{
    private double width;
    private double height;

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.height = value;
        }
    }

    public BasicShape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();
}