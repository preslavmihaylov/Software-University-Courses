using System;

class Component
{
    private string name;
    private string details;
    private double price;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.name = value;
        }
    }

    public double Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.price = value;
        }
    }

    public string Details
    {
        get
        {
            return this.details;
        }

        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.details = value;
        }
    }

    public Component(string name, string details, double price)
    {
        this.Name = name;
        this.Price = price;
        this.details = details;
    }

    public Component(string name, double price) : this(name, "None", price)
    {
    }

    public override string ToString()
    {
        string output = "";
        output += new string(' ', 5) + "Name: " + this.Name + Environment.NewLine;
        output += new string(' ', 5) + "Details: " + this.Details + Environment.NewLine;
        output += new string(' ', 5) + "Price: " + String.Format("{0:C}", this.Price) + Environment.NewLine;
        output += Environment.NewLine;
        return output;
    }
}
