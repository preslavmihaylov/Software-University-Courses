using System;

public class Project : IProject
{
    private string name;
    private DateTime startDate;
    private string details;
    private string state;

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
                throw new ArgumentException("The value cannot be null or empty.");
            }
            this.name = value;
        }
    }

    public DateTime StartDate
    {
        get 
        {
            return this.startDate;
        }
        private set
        {
            this.startDate = value;
        }
    }

    public string Details
    {
        get
        {
            return this.details;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                value = "No details";
            }
            this.details = value;
        }
    }

    public string State
    {
        get 
        {
            return this.state; 
        }
        private set
        {
            if (value != "closed" && value != "open")
            {
                throw new ArgumentException("The state of the project can be only closed or open.");
            }
            this.state = value;
        }
    }

    public Project(string name, DateTime startDate, string details, string state)
    {
        this.Name = name;
        this.StartDate = startDate;
        this.Details = details;
        this.State = state;
    }

    public Project(string name, DateTime startDate, string state)
    {
        this.Name = name;
        this.StartDate = startDate;
        this.Details = "";
        this.State = state;
    }

    public void CloseProject()
    {
        this.State = "closed";
    }

    public override string ToString()
    {
        string output = "";
        output += "Project Name: " + this.Name + Environment.NewLine;
        output += "Start Date: " + this.StartDate.ToString("dd-MM-yyyy") + Environment.NewLine;
        output += "Details: " + this.Details + Environment.NewLine;
        output += "State: " + this.State + Environment.NewLine;
        return output;
    }
}
