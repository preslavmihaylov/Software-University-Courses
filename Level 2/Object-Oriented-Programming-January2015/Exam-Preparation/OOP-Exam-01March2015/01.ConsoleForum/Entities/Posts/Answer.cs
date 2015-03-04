namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Text;
    using Contracts;

    public class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat(
                "[ Answer ID: {0} ]" + Environment.NewLine +
                "Posted by: {1}" + Environment.NewLine +
                "Answer Body: {2}" + Environment.NewLine +
                "--------------------",
                this.Id,
                this.Author.Username,
                this.Body);

            return output.ToString();
        }
    }
}
