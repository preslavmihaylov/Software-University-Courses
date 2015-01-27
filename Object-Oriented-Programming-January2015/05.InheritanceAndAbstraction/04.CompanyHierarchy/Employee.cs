using System;

public abstract class Employee : Person, IEmployee
{
    private double salary;
    private string department;

    public double Salary
    {
        get
        {
            return this.salary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The salary cannot be a negative number");
            }
            this.salary = value;
        }
    }

    public string Department
    {
        get
        {
            return this.department;
        }
        set
        {
            if (value != "Production" && value != "Sales" && value != "Accounting" && value != "Marketing")
            {
                throw new ArgumentException("The department can only be amongst the following: Production, Sales, Accounting, Marketing");
            }
            this.department = value;
        }
    }

    public Employee(string firstName, string lastName, double salary, string department) : base(firstName, lastName)
    {
        this.Salary = salary;
        this.Department = department;
    }

    public override string ToString()
    {
        string output = "";
        output += "Salary: " + this.Salary + Environment.NewLine;
        output += "Department: " + this.Department + Environment.NewLine;
        return base.ToString() + output;
    }
}
