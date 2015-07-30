namespace _01.NewsDB
{
    using Context;
    using Models;

    class NewsDBDemo
    {
        static void Main()
        {
            NewsContext newsContext = new NewsContext();
            Article article = new Article();
            article.Content = "New article";
            newsContext.Articles.Add(article);
            newsContext.SaveChanges();
        }
    }
}
