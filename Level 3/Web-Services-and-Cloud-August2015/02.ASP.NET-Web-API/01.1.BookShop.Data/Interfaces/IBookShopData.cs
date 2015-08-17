namespace _01._1.BlogSystem.Interfaces
{
    using BookShop.Data.Models;

    public interface IBookShopData
    {
        IRepository<Author> Authors { get; }

        IRepository<Book> Books { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Purchase> Purchases { get; }

        int SaveChanges();
    }
}