namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            int id = int.Parse(this.Data[1]);

            var question = this.Forum.Questions.FirstOrDefault(q => q.Id == id);
            if (question != null)
            {
                this.Forum.CurrentQuestion = question;
                this.Forum.Output.AppendLine(question.ToString());
            }
            else
            {
                throw new CommandException(Messages.NoQuestion);
            }
        }
    }
}
