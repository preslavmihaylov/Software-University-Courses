namespace _02.ConcurrentUpdates
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using _01.NewsDB.Context;
    using _01.NewsDB.Models;

    class ConcurrentUpdatesDemo
    {
        static void Main()
        {
            NewsContext context = new NewsContext();

                Article firstArticle = context.Articles.First();

                Console.WriteLine("Old Content: " + firstArticle.Content);
                Console.Write("Enter a new Content for the first article: ");
                string newContent = Console.ReadLine();
            
                firstArticle.Content = newContent;

            bool isSaved = false;
            do
            {
                try
                {
                    context.SaveChanges();
                    isSaved = true;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    isSaved = false;
                    var entry = e.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                    Console.WriteLine("Conflicting Updates");
                    Console.WriteLine("Update found: " + entry.OriginalValues.GetValue<string>("Content"));
                    Console.Write("New Content: ");
                    firstArticle.Content = Console.ReadLine();
                }
            } while (!isSaved);
        }
    }
}