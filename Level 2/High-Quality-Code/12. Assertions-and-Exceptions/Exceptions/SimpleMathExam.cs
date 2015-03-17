using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        private set
        {
            if (problemsSolved < 0 || problemsSolved > 10)
            {
                throw new ArgumentException("The problems solved must be in range [0..10]");
            }
            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved >= 0 && this.ProblemsSolved <= 2)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved >= 3 && this.ProblemsSolved <= 4)
        {
            return new ExamResult(3, 2, 6, "Average result: you might have done better.");
        }
        else if (this.ProblemsSolved >= 5 && this.ProblemsSolved <= 6)
        {
            return new ExamResult(4, 2, 6, "Good result: Not too good, not too bad.");
        }
        else if (this.ProblemsSolved >= 7 && this.ProblemsSolved <= 9)
        {
            return new ExamResult(5, 2, 6, "Very good result: Very good work, keep it up and you might get an Excellent.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Excellent Score: Great work!");   
        }
    }
}
