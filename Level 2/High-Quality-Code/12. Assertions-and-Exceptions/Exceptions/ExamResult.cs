using System;

public class ExamResult
{
    private int grade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (value < this.MinGrade || value > this.MaxGrade)
            {
                throw new ArgumentOutOfRangeException("The grade is not in the range [" + this.MinGrade + ".." + this.MaxGrade + "]");
            }
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get;
        private set;
    }

    public int MaxGrade
    {
        get;
        private set;
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (value == null)
            {
                throw new ArgumentException("The comments cannot be a null value.");
            }
            this.comments = value;
        }
    }
}
