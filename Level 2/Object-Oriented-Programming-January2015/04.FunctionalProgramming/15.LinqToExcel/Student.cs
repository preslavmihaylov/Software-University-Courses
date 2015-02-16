using System;

class Student
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string Type { get; set; }
    public int ExamResult { get; set; }
    public int HomeworksSent { get; set; }
    public int HomeworksEvaluated { get; set; }
    public double TeamworkScore { get; set; }
    public int AttendancesCount { get; set; }
    public double Bonus { get; set; }

    public Student(int id, string firstName, string lastName, string email,
                   string gender, string type, int examResult,
                   int homeworksSent, int homeworksEvaluated, double teamworkScore,
                   int attendancesCount, double bonus)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Gender = gender;
        this.Type = type;
        this.ExamResult = examResult;
        this.HomeworksSent = homeworksSent;
        this.HomeworksEvaluated = homeworksEvaluated;
        this.TeamworkScore = teamworkScore;
        this.AttendancesCount = attendancesCount;
        this.Bonus = bonus;
    }

    public double CalculateResult()
    {
        return (double)(this.ExamResult + this.HomeworksSent + this.HomeworksEvaluated + this.TeamworkScore + this.AttendancesCount + this.Bonus) / 5;
    }
}