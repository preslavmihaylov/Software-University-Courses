using System;
using System.ComponentModel.DataAnnotations;

class Homework
{
    // •	Homework: id, content, content-type (e.g. application/pdf or application/zip), submission date

    public int HomeworkId
    {
        get;
        set;
    }

    [Required]
    public string Content
    {
        get;
        set;
    }

    [Required]
    public ContentType ContentType
    {
        get;
        set;
    }

    [Required]
    public DateTime SubmissionDate
    {
        get;
        set;
    }

    public int CourseId
    {
        get;
        set;
    }

    public virtual Course Course
    {
        get;
        set;
    }

    public int StudentId
    {
        get;
        set;
    }

    public virtual Student Student
    {
        get;
        set;
    }
}