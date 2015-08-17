namespace _01._1.BlogSystem.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Interfaces;
    using System.Data.Entity.Infrastructure;
    using BookShop.Data;
    using Data;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private IBookShopDbContext context;

        public GenericRepository()
            : this(new BookShopDbContext())
        {
        }

        public GenericRepository(IBookShopDbContext blogSystemDbContext)
        {
            this.context = blogSystemDbContext;
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.All().Where(expression);
        }

        public T GetById(object id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public void Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void Detach(T entity)
        {
            ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = state;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            return entry;
        }
    }
}