using System;

class Payment : ICloneable
{
    public Payment() : this("", 0)
    {

    }

    public Payment(string productName, double price)
    {
        this.ProductName = productName;
        this.Price = price;
    }

    public string ProductName { get; set; }
    public double Price { get; set; }

    public object Clone()
    {
        Payment payment = new Payment();
        payment.ProductName = this.ProductName;
        payment.Price = this.Price;

        return payment;
    }
}
