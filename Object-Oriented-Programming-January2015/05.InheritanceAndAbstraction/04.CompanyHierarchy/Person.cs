using System;

public abstract class Person : IPerson
{
    private string firstName;
    private string lastName;
    private int id;
    private static int idCounter = 1;

    public int ID
    {
        get
        {
            return this.id;
        }
    }

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

    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.id = Person.idCounter;
        Person.idCounter++;
    }

    public override string ToString()
    {
        string output = "";
        output += "First Name: " + this.FirstName + Environment.NewLine;
        output += "Last Name: " + this.LastName + Environment.NewLine;
        output += "ID: " + this.ID + Environment.NewLine;
        return output;
    }
}