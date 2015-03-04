namespace ConsoleForum.Entities.Posts
{
    using System;
    using Contracts;

    public abstract class Post : IPost
    {
        private int id;
        private string body;
        private IUser author;

        protected Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
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
                    throw new ArgumentException("The id cannot be negative or zero.");
                }

                this.id = value;
            }
        }

        public string Body
        {
            get
            {
                return this.body;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The body of the post cannot be null or empty.");
                }

                this.body = value;
            }
        }

        public IUser Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The author cannot be null.");
                }

                this.author = value;
            }
        }
    }
}
