using System;

public class Sales : ISales
{
    private string productName;
    private DateTime date;
    private double price;

    public string ProductName
    {
        get
        {
            return this.productName;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The name of the product cannot be null or empty");
            }
            this.productName = value;
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
                throw new ArgumentException("The price cannot be a negative number.");
            }
            this.price = value;
        }
    }

    public DateTime Date
    {
        get 
        {
            return this.date; 
        }
        private set
        {
            this.date = value;
        }
    }

    public Sales(string productName, double price)
    {
        this.ProductName = productName;
        this.Price = price;
        this.Date = DateTime.Now;
    }

    public override string ToString()
    {
        string output = "";
        output += "Product Name: " + this.ProductName + Environment.NewLine;
        output += "Price: " + this.Price + Environment.NewLine;
        output += "Date: " + this.Date.ToString("dd-MM-yyyy") + Environment.NewLine;
        return output;
    }
}
