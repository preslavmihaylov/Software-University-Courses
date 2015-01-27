using System;

abstract class Human
{
    private string firstName;
    private string lastName;

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

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}
