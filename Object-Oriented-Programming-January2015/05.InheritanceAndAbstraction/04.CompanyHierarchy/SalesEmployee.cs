using System;
using System.Collections.Generic;

public class SalesEmployee : Employee, ISalesEmployee
{
    List<Sales> sales;

    public List<Sales> Sales
    {
        get 
        {
            return this.sales; 
        }
        private set
        {
            this.sales = value;
        }
    }

    public SalesEmployee(string firstName, string lastName, double salary, string department) 
        : base(firstName, lastName, salary, department)
    {
        this.Sales = new List<Sales>();
    }

    public SalesEmployee(string firstName, string lastName, double salary, string department, List<Sales> sales)
        : base(firstName, lastName, salary, department)
    {
        this.Sales = sales;
    }

    public override string ToString()
    {
        string output = "Sales: " + Environment.NewLine;
        foreach (var product in this.Sales)
        {
            output += new string(' ', 5) + product.ToString() + Environment.NewLine;
        }
        return base.ToString() + output;
    }
}
