namespace ConsoleForum.Entities.Users
{
    using System;
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public class User : IUser
    {
        private int id;
        private string username;
        private string password;
        private string email;

        public User(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The id cannot be null or empty.");
                }

                this.id = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The username cannot be null or empty.");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The password cannot be null or empty.");
                }

                this.password = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The email cannot be null or empty.");
                }

                this.email = value;
            }
        }

        public IList<IQuestion> Questions { get; private set; }
    }
}
