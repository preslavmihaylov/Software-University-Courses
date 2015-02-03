using System;

class Customer : Person, ICustomer
{
    private double netPurchaseAmount;

    public double NetPurchaseAmount
    {
        get
        {
            return this.netPurchaseAmount;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.netPurchaseAmount = value;
        }
    }

    public Customer(string firstName, string lastName, double netPurchaseAmount) : base(firstName, lastName)
    {
        this.NetPurchaseAmount = netPurchaseAmount;
    }

    public override string ToString()
    {
        string output = "";
        output += "Type: Customer" + Environment.NewLine;
        output += "Net Purchase Amount: " + this.NetPurchaseAmount + Environment.NewLine;
        return base.ToString() + output;
    }
}