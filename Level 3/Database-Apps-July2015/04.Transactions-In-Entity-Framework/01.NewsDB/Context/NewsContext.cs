namespace _01.NewsDB.Context
{
    using System.Data.Entity;
    using Models;

    public class NewsContext : DbContext
    {
        public NewsContext() 
            : base("NewsDB")
        {
        }

        public DbSet<Article> Articles
        {
            get;
            set;
        }
    }
}
