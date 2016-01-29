namespace _03.CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class CollectionOfProducts : ICollectionOfProducts
    {
        #region Private Data Structure Fields
        // Dictionary<id, Product>
        private Dictionary<int, Product> productsById;
        
        // SortedDictionary<Price, SortedSet<Product>>
        private OrderedDictionary<decimal, SortedSet<Product>> productsByPriceRange; 

        // Dictionary<title, SortedSet<Product>>
        private Dictionary<string, SortedSet<Product>> productsByTitle; 

        // Dictionary<title-price, SortedSet<Product>>
        private Dictionary<string, SortedSet<Product>> productsByTitleAndPrice; 

        // Dictionary<title, SortedDictionary<price, SortedSet<Product>>>
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByTitleAndPriceRange;

        // Dictionary<supplier-price, SortedSet<Product>>
        private Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice; 

        // Dictionary<supplier, SortedDictionary<price, SortedSet<Product>>>
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsBySupplierAndPriceRange;
        #endregion

        public CollectionOfProducts()
        {
            #region Data Structures Initialization
            this.productsById = new Dictionary<int, Product>();
            this.productsByPriceRange = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.productsBySupplierAndPrice = new Dictionary<string, SortedSet<Product>>();
            this.productsBySupplierAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            #endregion
        }

        public int Count
        {
            get { return this.productsById.Count; }
        }

        public void Add(Product product)
        {
            this.AddProductById(product);
            this.AddProductByPriceRange(product);
            this.AddProductByTitle(product);
            this.AddProductBySupplierAndPrice(product);
            this.AddProductBySupplierAndPriceRange(product);
            this.AddProductByTitleAndPrice(product);
            this.AddProductByTitleAndPriceRange(product);
        }

        public bool Remove(int id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }

            Product product = this.productsById[id];

            this.RemoveProductById(product);
            this.RemoveProductByPriceRange(product);
            this.RemoveProductBySupplierAndPrice(product);
            this.RemoveProductBySupplierAndPriceRange(product);
            this.RemoveProductByTitle(product);
            this.RemoveProductByTitleAndPrice(product);
            this.RemoveProductByTitleAndPriceRange(product);

            return true;
        }

        #region Public Find Methods
        public Product Find(int id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return null;
            }

            return this.productsById[id]; 
        }

        public IEnumerable<Product> Find(decimal startPrice, decimal endPrice)
        {
            SortedSet<Product> result = new SortedSet<Product>();

            var priceRange = 
                this.productsByPriceRange.Range(startPrice, true, endPrice, true);

            foreach (var range in priceRange)
            {
                foreach (var product in range.Value)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public IEnumerable<Product> Find(string title)
        {
            if (!this.productsByTitle.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitle[title];
        }

        public IEnumerable<Product> Find(string title, decimal price)
        {
            string key = this.GetUniqueKey(title, price);
            if (!this.productsByTitleAndPrice.ContainsKey(key))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[key];
        }

        public IEnumerable<Product> Find(string title, decimal startPrice, decimal endPrice)
        {
            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            SortedSet<Product> result = new SortedSet<Product>();

            var priceRange = 
                this.productsByTitleAndPriceRange[title].Range(startPrice, true, endPrice, true);

            foreach (var range in priceRange)
            {
                foreach (var product in range.Value)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public IEnumerable<Product> FindBySupplier(string supplier, decimal price)
        {
            string key = this.GetUniqueKey(supplier, price);

            if (!this.productsBySupplierAndPrice.ContainsKey(key))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsBySupplierAndPrice[key];
        }

        public IEnumerable<Product> FindBySupplier(string supplier, decimal startPrice, decimal endPrice)
        {
            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }

            SortedSet<Product> result = new SortedSet<Product>();

            var priceRange = this.productsBySupplierAndPriceRange[supplier].Range(startPrice, true, endPrice, true);

            foreach (var range in priceRange)
            {
                foreach (var product in range.Value)
                {
                    result.Add(product);
                }
            }

            return result;
        }
        #endregion

        #region Private Add Methods
        private void AddProductById(Product product)
        {
            this.productsById[product.Id] = product;
        }
        
        private void AddProductByPriceRange(Product product)
        {
            if (!this.productsByPriceRange.ContainsKey(product.Price))
            {
                this.productsByPriceRange[product.Price] = 
                    new SortedSet<Product>();
            }

            if (this.productsByPriceRange[product.Price].Contains(product))
            {
                this.productsByPriceRange[product.Price].Remove(product);
            }

            this.productsByPriceRange[product.Price].Add(product);
        }

        private void AddProductByTitle(Product product)
        {
            if (!this.productsByTitle.ContainsKey(product.Title))
            {
                this.productsByTitle[product.Title] = 
                    new SortedSet<Product>();
            }

            if (this.productsByTitle[product.Title].Contains(product))
            {
                this.productsByTitle[product.Title].Remove(product);
            }

            this.productsByTitle[product.Title].Add(product);
        }

        private void AddProductBySupplierAndPrice(Product product)
        {
            string key = this.GetUniqueKey(product.Supplier, product.Price);

            if (!this.productsBySupplierAndPrice.ContainsKey(key))
            {
                this.productsBySupplierAndPrice[key] =
                    new SortedSet<Product>();
            }

            if (this.productsBySupplierAndPrice[key].Contains(product))
            {
                this.productsBySupplierAndPrice[key].Remove(product);
            }

            this.productsBySupplierAndPrice[key].Add(product);
        }

        private void AddProductBySupplierAndPriceRange(Product product)
        {
            if (!this.productsBySupplierAndPriceRange.ContainsKey(product.Supplier))
            {
                this.productsBySupplierAndPriceRange[product.Supplier] =
                    new OrderedDictionary<decimal, SortedSet<Product>>();
            }

            OrderedDictionary<decimal, SortedSet<Product>> a = this.productsBySupplierAndPriceRange[product.Supplier];
            
            if (!this.productsBySupplierAndPriceRange[product.Supplier].ContainsKey(product.Price))
            {
                this.productsBySupplierAndPriceRange[product.Supplier][product.Price] = new SortedSet<Product>();
            }

            if (this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Contains(product))
            {
                this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);
            }

            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
        }

        private void AddProductByTitleAndPrice(Product product)
        {
            string key = this.GetUniqueKey(product.Title, product.Price);

            if (!this.productsByTitleAndPrice.ContainsKey(key))
            {
                this.productsByTitleAndPrice[key] = 
                    new SortedSet<Product>();
            }

            if (this.productsByTitleAndPrice[key].Contains(product))
            {
                this.productsByTitleAndPrice[key].Remove(product);
            }

            this.productsByTitleAndPrice[key].Add(product);
        }

        private void AddProductByTitleAndPriceRange(Product product)
        {
            if (!this.productsByTitleAndPriceRange.ContainsKey(product.Title))
            {
                this.productsByTitleAndPriceRange[product.Title] =
                    new OrderedDictionary<decimal, SortedSet<Product>>();
            }

            if (!this.productsByTitleAndPriceRange[product.Title].ContainsKey(product.Price))
            {
                this.productsByTitleAndPriceRange[product.Title][product.Price] = 
                    new SortedSet<Product>();
            }

            if (this.productsByTitleAndPriceRange[product.Title][product.Price].Contains(product))
            {
                this.productsByTitleAndPriceRange[product.Title][product.Price].Remove(product);
            }

            this.productsByTitleAndPriceRange[product.Title][product.Price].Add(product);
        }
        #endregion

        #region Private Remove Methods
        private void RemoveProductById(Product product)
        {
            this.productsById.Remove(product.Id);
        }

        private void RemoveProductByPriceRange(Product product)
        {
            this.productsByPriceRange[product.Price].Remove(product);
            if (this.productsByPriceRange[product.Price].Count == 0)
            {
                this.productsByPriceRange.Remove(product.Price);
            }
        }

        private void RemoveProductByTitle(Product product)
        {
            this.productsByTitle[product.Title].Remove(product);
            if (this.productsByTitle[product.Title].Count == 0)
            {
                this.productsByTitle.Remove(product.Title);
            }
        }

        private void RemoveProductBySupplierAndPrice(Product product)
        {
            string key = this.GetUniqueKey(product.Supplier, product.Price);

            this.productsBySupplierAndPrice[key].Remove(product);
            if (this.productsBySupplierAndPrice[key].Count == 0)
            {
                this.productsBySupplierAndPrice.Remove(key);
            }
        }

        private void RemoveProductBySupplierAndPriceRange(Product product)
        {
            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);

            if (this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Count == 0)
            {
                this.productsBySupplierAndPriceRange[product.Supplier].Remove(product.Price);

                if (this.productsBySupplierAndPriceRange[product.Supplier].Count == 0)
                {
                    this.productsBySupplierAndPriceRange.Remove(product.Supplier);
                }
            }
        }

        private void RemoveProductByTitleAndPrice(Product product)
        {
            string key = this.GetUniqueKey(product.Title, product.Price);

            this.productsByTitleAndPrice[key].Remove(product);
            if (this.productsByTitleAndPrice[key].Count == 0)
            {
                this.productsByTitleAndPrice.Remove(key);
            }
        }

        private void RemoveProductByTitleAndPriceRange(Product product)
        {
            this.productsByTitleAndPriceRange[product.Title][product.Price].Remove(product);

            if (this.productsByTitleAndPriceRange[product.Title][product.Price].Count == 0)
            {
                this.productsByTitleAndPriceRange[product.Title].Remove(product.Price);

                if (this.productsByTitleAndPriceRange[product.Title].Count == 0)
                {
                    this.productsByTitleAndPriceRange.Remove(product.Title);
                }
            }
        }
        #endregion

        private string GetUniqueKey(object first, object second)
        {
            return first + "-" + second;
        }
    }
}