namespace _03.CollectionOfProducts
{
    using System.Collections.Generic;

    public interface ICollectionOfProducts
    {
        void Add(Product product);

        int Count { get; }

        bool Remove(int id);

        Product Find(int id); 

        IEnumerable<Product> Find(decimal startPrice, decimal endPrice);

        IEnumerable<Product> Find(string title);

        IEnumerable<Product> Find(string title, decimal price);

        IEnumerable<Product> Find(string title, decimal startPrice, decimal endPrice);

        IEnumerable<Product> FindBySupplier(string supplier, decimal price);

        IEnumerable<Product> FindBySupplier(string supplier, decimal startPrice, decimal endPrice);
    }
}