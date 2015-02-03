using System;
using System.Collections.Generic;

class School
{
    private string name;
    public List<Class> Classes { get; set; }

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
                throw new ArgumentException();
            }
            this.name = value;
        }
    }

    public School(string name, List<Class> classes)
    {
        this.Name = name;
        this.Classes = classes;
    }

    public School(string name)
    {
        this.Name = name;
        this.Classes = new List<Class>();
    }

    public override string ToString()
    {
        string output = "";
        output += "School name: " + this.Name + Environment.NewLine;
        output += "Classes: " + Environment.NewLine;
        foreach (var element in this.Classes)
        {
            output += element.ToString() + Environment.NewLine;
        }
        return output;
    }
}
