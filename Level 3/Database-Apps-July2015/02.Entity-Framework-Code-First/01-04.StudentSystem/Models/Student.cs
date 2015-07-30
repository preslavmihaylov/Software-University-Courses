using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Student
{
    // •	Students: id, name, phone number (optional), registration date, birthday (optional)

    private ICollection<Course> courses;
    private ICollection<Homework> homeworks;

    public Student()
    {
        this.courses = new HashSet<Course>();
        this.homeworks = new HashSet<Homework>();
    }

    public int StudentId { get; set; }

    [Required]
    public string Name
    {
        get;
        set;
    }

    public string PhoneNumber
    {
        get;
        set;
    }

    [Required]
    public DateTime RegistrationDate
    {
        get;
        set;
    }

    public DateTime Birthday
    {
        get;
        set;
    }

    public virtual ICollection<Course> Courses
    {
        get
        {
            return this.courses;
        }
        set
        {
            this.courses = value;
        }
    }

    public virtual ICollection<Homework> Homeworks
    {
        get
        {
            return this.homeworks;
        }
        set
        {
            this.homeworks = value;
        }
    }
}