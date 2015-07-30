namespace _01.NewsDB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public int ArticleId
        {
            get;
            set;
        }

        [ConcurrencyCheck]
        public string Content
        {
            get;
            set;
        }
    }
}