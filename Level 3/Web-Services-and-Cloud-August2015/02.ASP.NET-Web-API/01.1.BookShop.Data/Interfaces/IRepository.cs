namespace _01._1.BlogSystem.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        void Detach(T entity);
    }
}