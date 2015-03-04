namespace ConsoleForum.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Utility;

    public class RegisterCommand : AbstractCommand
    {
        public RegisterCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);
            string email = this.Data[3];

            if (users.Any(u => u.Username == username || u.Email == email))
            {
                throw new CommandException(Messages.UserAlreadyRegistered);
            }

            User user = null;

            if (this.Data.Count > 4)
            {
                var role = this.Data[4];

                switch (role.ToLower())
                {
                    case "administrator":
                        if (users.Any())
                        {
                            throw new CommandException(Messages.RegAdminNotAllowed);
                        }

                        user = new Administrator(users.Count + 1, username, password, email);

                        break;
                    default:
                        user = CreateRegularUser(username, email, password);
                        break;
                }
            }
            else
            {
                user = CreateRegularUser(username, email, password);
            }

            if (user != null)
            {
                users.Add(user);

                this.Forum.Output.AppendLine(
                    string.Format(Messages.RegisterSuccess, username, users.Last().Id));
            }
            else
            {
                throw new CommandException(Messages.UserAlreadyRegistered);
            }
        }

        private User CreateRegularUser(string username, string email, string password)
        {
            var sameUser = this.Forum.Users.FirstOrDefault(u => u.Username == username || u.Email == email);

            if (sameUser == null)
            {
                User user = new User(this.Forum.Users.Count + 1, username, password, email);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
