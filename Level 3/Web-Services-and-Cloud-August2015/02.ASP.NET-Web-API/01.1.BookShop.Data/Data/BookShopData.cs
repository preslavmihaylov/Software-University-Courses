namespace _01._1.BlogSystem.Data
{
    using System;
    using System.Collections.Generic;
    using BookShop.Data;
    using BookShop.Data.Models;
    using Interfaces;
    using Repositories;

    public class BookShopData : IBookShopData
    {
        private IBookShopDbContext context;
        private IDictionary<Type, object> repositories;

        public BookShopData()
            : this(new BookShopDbContext())
        {
        }

        public BookShopData(IBookShopDbContext blogSystemDbContext)
        {
            this.context = blogSystemDbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Author> Authors
        {
            get { return this.GetRepository<Author>(); }
        }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Purchase> Purchases
        {
            get
            {
                return this.GetRepository<Purchase>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}