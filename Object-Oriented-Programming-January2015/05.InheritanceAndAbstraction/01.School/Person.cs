using System;

abstract class Person
{
    private string name;
    private int age;
    private string details;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.name = value;
        }
    }

    public string Details
    {
        get
        {
            if (this.details == null)
            {
                return "No details";
            }
            else
            {
                return this.details;
            }
        }
        set
        {
            this.details = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException();
            }
            this.age = value;
        }
    }

    public Person(string name, int age, string details)
    {
        this.Name = name;
        this.Age = age;
        this.Details = details;
    }

    public override string ToString()
    {
        string output = "";
        output += "Name: " + this.Name + Environment.NewLine;
        output += "Age: " + this.Age + Environment.NewLine;
        output += "Details: " + this.Details + Environment.NewLine;
        return output;
    }
}
