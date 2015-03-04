namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.Questions.Any())
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {
                for (int index = 0; index < this.Forum.Questions.Count; index++)
                {
                    if (index < this.Forum.Questions.Count)
                    {
                        this.Forum.Output.AppendLine(this.Forum.Questions[index].ToString());
                    }
                    else
                    {
                        this.Forum.Output.Append(this.Forum.Questions[index].ToString());
                    }
                }
            }
        }
    }
}
