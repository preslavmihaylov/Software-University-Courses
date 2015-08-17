namespace _01._1.BookShop.Data
{
    using System.Data.Entity;
    using BlogSystem.Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using StudentSystem.Data.Migrations;

    public class BookShopDbContext : IdentityDbContext<ApplicationUser>, IBookShopDbContext
    {
        public BookShopDbContext()
            : base("BookShop")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static BookShopDbContext Create()
        {
            return new BookShopDbContext();
        }
    }
}