namespace ConsoleForum.Entities.Posts
{
    using System;
    using Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            return 
                "********************" + Environment.NewLine +
                base.ToString() + Environment.NewLine +
                "********************";
        }
    }
}