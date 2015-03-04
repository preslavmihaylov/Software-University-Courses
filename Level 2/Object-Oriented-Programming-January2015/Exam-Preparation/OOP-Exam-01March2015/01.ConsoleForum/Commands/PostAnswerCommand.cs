namespace ConsoleForum.Commands
{
    using System;
    using Contracts;
    using Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            else if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            else
            {
                string body = this.Data[1];

                var totalAnswerIds = 0;
                foreach (var question in this.Forum.Questions)
                {
                    totalAnswerIds += question.Answers.Count;
                }

                this.Forum.CurrentQuestion.Answers.Add(
                    new Answer(
                        totalAnswerIds + 1,
                        body,
                        this.Forum.CurrentUser));

                this.Forum.Output.AppendLine(
                    string.Format(Messages.PostAnswerSuccess, totalAnswerIds + 1));
            }
        }
    }
}
