using System;

class Worker : Human
{
    private double weekSalary;
    private int workHours;

    public double WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The value cannot be negative.");
            }
            this.weekSalary = value;
        }
    }

    public int WorkHours
    {
        get
        {
            return this.workHours;
        }
        set
        {
            if (value < 0 || value > 12)
            {
                throw new ArgumentException("The value cannot be negative and it can exceed 12 hours per day.");
            }
            this.workHours = value;
        }
    }

    public Worker(string firstName, string lastName, double weekSalary, int workHours) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.workHours = workHours;
    }

    public double MoneyPerHour()
    {
        // Assuming the guy works 5 days in a week
        return (weekSalary / 5) / workHours;
    }
}
