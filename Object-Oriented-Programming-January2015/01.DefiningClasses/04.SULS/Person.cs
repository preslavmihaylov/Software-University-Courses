using System;
class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.age = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public override string ToString()
    {
        string output = "";
        output += "First Name: " + this.FirstName + Environment.NewLine;
        output += "Last Name: " + this.LastName + Environment.NewLine;
        output += "Age: " + this.Age + Environment.NewLine;
        return output;
    }
}
