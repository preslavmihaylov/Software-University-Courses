namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class Question : Post, IQuestion
    {
        private string title;
        private IList<IAnswer> answers = new List<IAnswer>();

        public Question(int id, string title, string body, IUser author)
            : base(id, body, author)
        {
            this.Title = title;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title cannot be null or empty.");
                }

                this.title = value;
            }
        }

        public IList<IAnswer> Answers
        {
            get
            {
                return this.answers;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat(
                "[ Question ID: {0} ]" + Environment.NewLine +
                "Posted by: {1}" + Environment.NewLine +
                "Question Title: {2}" + Environment.NewLine +
                "Question Body: {3}" + Environment.NewLine +
                "====================" + Environment.NewLine,
                this.Id,
                this.Author.Username,
                this.Title,
                this.Body);

            if (this.Answers.Any())
            {
                output.AppendLine("Answers:");
                var bestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer);
                if (bestAnswer != null)
                {
                    output.AppendLine(bestAnswer.ToString());
                }

                foreach (var answer in this.Answers)
                {
                    if (!(answer is BestAnswer))
                    {
                        output.AppendLine(answer.ToString());
                    }
                }

                // Removes the last newline
                output.Remove(output.Length - 2, 2); 
            }
            else
            {
                output.Append("No answers");
            }

            return output.ToString();
        }
    }
}
