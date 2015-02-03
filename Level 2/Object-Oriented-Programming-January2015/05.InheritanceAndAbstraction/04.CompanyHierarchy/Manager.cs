using System;
using System.Collections.Generic;

class Manager : Employee, IManager
{
    private List<Employee> subordinates;

    public List<Employee> Subordinates
    {
        get
        {
            return this.subordinates;
        }
        private set
        {
            this.subordinates = value;
        }
    }

    public Manager(string firstName, string lastName, double salary, string department) 
        : base(firstName, lastName, salary, department)
    {
        this.Subordinates = new List<Employee>();
    }

    public Manager(string firstName, string lastName, double salary, string department, List<Employee> subordinates)
        : base(firstName, lastName, salary, department)
    {
        this.Subordinates = subordinates;
    }

    public override string ToString()
    {
        string output = "Subordinates: " + Environment.NewLine;
        foreach (var subordinate in this.Subordinates)
        {
            output += new string(' ', 5) + subordinate.FirstName + " " + subordinate.LastName + " -- ID: " + subordinate.ID + Environment.NewLine;
        }
        return base.ToString() + output;
    }
}
