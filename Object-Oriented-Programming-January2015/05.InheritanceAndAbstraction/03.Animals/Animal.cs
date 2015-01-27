using System;

abstract class Animal
{
    private string name;
    private int age;
    private string gender;

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
                throw new ArgumentException("The name cannot be null or empty");
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
        private set
        {
            if (value <= 0 || value > 100)
            {
                throw new ArgumentException("The age cannot be negative, zero or above 100");
            }
            this.age = value;
        }
    }

    public string Gender
    {
        get
        {
            return this.gender;
        }
        private set
        {
            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException("The gender cannot be different than male or female.");
            }
            this.gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public void GetOlder()
    {
        this.Age++;
    }
}
