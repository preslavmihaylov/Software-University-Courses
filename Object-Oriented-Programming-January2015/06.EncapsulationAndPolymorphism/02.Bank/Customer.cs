using System;

public abstract class Customer : ICustomer
{
    private string name;
    private int age;

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
                throw new ArgumentException();
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
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.age = value;
        }
    }

    public Customer(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
