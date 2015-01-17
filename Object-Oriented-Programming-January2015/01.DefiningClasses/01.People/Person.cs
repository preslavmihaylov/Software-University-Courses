using System;
using System.Text.RegularExpressions;

class Person
{
    private string name;
    private int age;
    private string email;
    private Regex regex = new Regex(".*@.*");

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The name cannot be null or empty.");
            }

            this.name = value;
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
            if ((value < 0 || value > 100))
            {
                throw new ArgumentOutOfRangeException("The age should be in the range [0..100]");
            }

            this.age = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            if (String.IsNullOrEmpty(value) || regex.IsMatch(value))
            {
                this.email = value;
            }
            else
            {
                throw new ArgumentException("The email should contain the character @.");
            }
        }
    }

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public Person(string name, int age)
        : this(name, age, null)
    {

    }

    public override string ToString()
    {
        if (String.IsNullOrEmpty(this.Email))
        {
            return "My name is " + this.Name + ". My age is " + this.Age + ". I don't have an email.";
        }
        else
        {
            return "My name is " + this.Name + ". My age is " + this.Age + ". My email is " + this.Email + ".";
        }
    }
}
