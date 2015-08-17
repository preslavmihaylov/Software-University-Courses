namespace _01._1.BlogSystem.Interfaces
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BookShop.Data.Models;

    public interface IBookShopDbContext
    {
        IDbSet<Book> Books { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Author> Authors { get; }

        IDbSet<Purchase> Purchases { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
