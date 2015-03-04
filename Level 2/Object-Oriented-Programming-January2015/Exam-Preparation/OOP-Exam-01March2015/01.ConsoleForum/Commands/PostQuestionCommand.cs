namespace ConsoleForum.Commands
{
    using System;
    using Contracts;
    using Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.IsLogged)
            {
                string title = this.Data[1];
                string body = this.Data[2];

                this.Forum.Questions.Add(new Question(this.Forum.Questions.Count + 1, title, body, this.Forum.CurrentUser));
                this.Forum.CurrentQuestion = this.Forum.Questions[this.Forum.Questions.Count - 1];

                this.Forum.Output.AppendLine(
                    string.Format(Messages.PostQuestionSuccess, this.Forum.Questions.Count));
            }
            else
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}
