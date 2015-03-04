namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using Entities.Posts;

    internal class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
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
                int answerId = int.Parse(this.Data[1]);

                var bestAnswer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(a => a.Id == answerId);

                if (bestAnswer == null)
                {
                    throw new CommandException(Messages.NoAnswer);
                }
                else
                {
                    if (this.Forum.CurrentUser.Id == this.Forum.CurrentQuestion.Author.Id ||
                        this.Forum.CurrentUser is IAdministrator)
                    {
                        this.Forum.CurrentQuestion.Answers[answerId - 1] = new BestAnswer(bestAnswer.Id, bestAnswer.Body, bestAnswer.Author);

                        this.Forum.Output.AppendLine(
                            string.Format(Messages.BestAnswerSuccess, bestAnswer.Id));
                    }
                    else
                    {
                        throw new CommandException(Messages.NoPermission);
                    }
                }
            }
        }
    }
}
