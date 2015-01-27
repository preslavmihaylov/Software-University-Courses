using System;
using System.Collections.Generic;
public class Developer : Employee, IDeveloper
{
    List<Project> projects;

    public List<Project> Projects
    {
        get
        {
            return this.projects;
        }
        private set
        {
            this.projects = value;
        }
    }

    public Developer(string firstName, string lastName, double salary, string department) 
        : base(firstName, lastName, salary, department)
    {
        this.Projects = new List<Project>();
    }

    public Developer(string firstName, string lastName, double salary, string department, List<Project> projects)
        : base(firstName, lastName, salary, department)
    {
        this.Projects = projects;
    }

    public override string ToString()
    {
        string output = "Projects: " + Environment.NewLine;
        foreach (var project in this.Projects)
        {
            output += new string(' ', 5) + project.ToString() + Environment.NewLine;
        }
        return base.ToString() + output;
    }
}
