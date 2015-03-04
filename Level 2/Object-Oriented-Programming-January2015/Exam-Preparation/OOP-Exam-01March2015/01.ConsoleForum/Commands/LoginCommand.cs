namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            // Login {username} {password} 
            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            var existingUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (existingUser != null)
            {
                this.Forum.CurrentUser = existingUser;
                this.Forum.Output.AppendLine(
                    string.Format(Messages.LoginSuccess, this.Forum.CurrentUser.Username));
            }
            else
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
        }
    }
}
