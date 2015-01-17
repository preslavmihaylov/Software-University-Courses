using System;
using System.Collections.Generic;

class Computer
{
    private string name;
    private double price;
    private List<Component> components = new List<Component>();

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
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.price = value;
        }
    }

    public Computer(string name, params Component[] components)
    {
        this.Name = name;

        foreach (Component component in components)
        {
            this.components.Add(component);
        }

        this.Price = this.getTotalPrice();
    }

    public override string ToString()
    {
        string output = "";
        output += "Computer name: " + this.Name + Environment.NewLine;
        output += "Components: " + Environment.NewLine;
        foreach (Component component in this.components)
        {
            output += component.ToString();
        }
        output += "Total Price: " + String.Format("{0:C}", this.Price) + Environment.NewLine;
        return output;
    }

    private double getTotalPrice()
    {
        double totalPrice = 0;
        foreach (Component component in this.components)
        {
            totalPrice += component.Price;
        }
        return totalPrice;
    }
}

