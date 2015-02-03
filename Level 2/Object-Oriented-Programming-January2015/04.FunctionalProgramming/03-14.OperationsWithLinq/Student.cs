using System;
using System.Collections.Generic;

class Student
{
    public Student(string firstName, string lastName, int age, int facultyNumber, 
                   string phone, string email, List<int> marks, int groupID)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.FacultyNumber = facultyNumber.ToString();
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupID = groupID;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string FacultyNumber { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public IList<int> Marks { get; set; }
    public int GroupID { get; set; }

    public static string ConcatMarks(IList<int> marks)
    {
        string output = "";
        foreach (var item in marks)
        {
            output += item + " ";
        }

        return output;
    } 

    public override string ToString()
    {
        string output =  "First name: " + this.FirstName + ", Last Name: " + this.LastName + ", Age: " + this.Age + Environment.NewLine + 
            "Faculty Number: " + this.FacultyNumber + ", Phone: " + this.Phone + Environment.NewLine +
            "Email: " + this.Email + ", Marks: ";
        foreach (var item in this.Marks)
        {
            output += item + " ";
        }
        output += "GroupID: " + this.GroupID;
        return output;
    }
}