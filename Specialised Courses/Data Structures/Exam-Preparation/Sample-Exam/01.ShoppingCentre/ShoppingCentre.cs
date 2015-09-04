namespace _01.ShoppingCentre
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    internal class ShoppingCentre
    {
        #region Data Structure Fields
        // Dictionary<producer, SortedSet<Product>>
        private static Dictionary<string, OrderedBag<Product>>
            productsByProducer;

        // Dictionary<name, SortedSet<Product>>
        private static Dictionary<string, OrderedBag<Product>>
            productsByName;

        // OrderedDictionary<price, List<Product>>
        private static OrderedDictionary<decimal, OrderedBag<Product>>
            productsByPriceRange;
        #endregion

        private static void Main()
        {
            InitializeDataStructures();
            ProcessInput();
        }

        #region Data Structures Initialization

        private static void InitializeDataStructures()
        {
            productsByName =
                new Dictionary<string, OrderedBag<Product>>();
            productsByPriceRange =
                new OrderedDictionary<decimal, OrderedBag<Product>>();
            productsByProducer =
                new Dictionary<string, OrderedBag<Product>>();
        }

        #endregion

        #region Command Processing

        private static void ProcessInput()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int count = 0; count < commandsCount; count++)
            {
                string[] commandParams =
                    Console.ReadLine().Split(' ');

                string command = commandParams[0];

                string productParamsFormat = "";

                for (int paramCount = 1;
                    paramCount < commandParams.Length;
                    paramCount++)
                {
                    productParamsFormat +=
                        " " + commandParams[paramCount];
                }

                string[] productParams =
                    productParamsFormat.Trim().Split(';');

                string output = ParseCommand(command, productParams);
                Console.WriteLine(output);
            }
        }

        private static string ParseCommand(string command, string[] productParams)
        {
            string output = "";

            switch (command)
            {
                case "AddProduct":
                    string name = productParams[0];
                    decimal price = decimal.Parse(productParams[1]);
                    string producer = productParams[2];

                    Product product = new Product()
                    {
                        Name = name,
                        Price = price,
                        Producer = producer
                    };

                    output = AddProduct(product);
                    break;
                case "DeleteProducts":
                    if (productParams.Length == 1)
                    {
                        producer = productParams[0];

                        output = DeleteProducts(producer);
                    }
                    else
                    {
                        name = productParams[0];
                        producer = productParams[1];

                        output = DeleteProducts(name, producer);
                    }
                    break;
                case "FindProductsByName":
                    name = productParams[0];

                    output = FindProductsByName(name);
                    break;
                case "FindProductsByProducer":
                    producer = productParams[0];

                    output = FindProductsByProducer(producer);
                    break;
                case "FindProductsByPriceRange":
                    decimal fromPrice = decimal.Parse(productParams[0]);
                    decimal toPrice = decimal.Parse(productParams[1]);

                    output = 
                        FindProductsByPriceRange(fromPrice, toPrice);
                    break;
                default:
                    throw new InvalidOperationException("Invalid input");
            }

            return output;
        }

        #endregion

        #region Main Commands
        private static string AddProduct(Product product)
        {
            AddProductByName(product);
            AddProductByPriceRange(product);
            AddProductByProducer(product);

            return "Product added";
        }

        private static string DeleteProducts(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                return "No products found";
            }

            var products = productsByProducer[producer];
            productsByProducer.Remove(producer);
            
            DeleteProductsByName(products);
            DeleteProductsByPriceRange(products);

            return 
                string.Format("{0} products deleted", products.Count);
        }

        private static string DeleteProducts(string name, string producer)
        {
            if (!productsByName.ContainsKey(name) ||
                !productsByProducer.ContainsKey(producer))
            {
                return "No products found";
            }

            var productsByNameProjection = productsByName[name];
            var productsByProducerProjection = productsByProducer[producer];

            var products = productsByNameProjection.Intersection(productsByProducerProjection);

            if (products.Count == 0)
            {
                return "No products found";
            }

            DeleteProductsByPriceRange(products);

            productsByName[name].RemoveMany(products);
            productsByProducer[producer].RemoveMany(products);

            return
               string.Format("{0} products deleted", products.Count);
        }

        private static string FindProductsByName(string name)
        {
            if (!productsByName.ContainsKey(name))
            {
                return "No products found";
            }

            var products = productsByName[name];

            if (products.Count == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, products);
        }

        private static string FindProductsByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                return "No products found";
            }

            var products = productsByProducer[producer];

            if (products.Count == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, products);
        }

        private static string FindProductsByPriceRange(decimal fromPrice, decimal toPrice)
        {
            var priceRange = 
                productsByPriceRange.Range(fromPrice, true, toPrice, true);

            var result = new OrderedBag<Product>();

            foreach (var range in priceRange)
            {
                foreach (var product in range.Value)
                {
                    result.Add(product);
                }
            }

            if (result.Count == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, result);
        }
        #endregion

        #region Add Products Methods
        private static void AddProductByName(Product product)
        {
            if (!productsByName.ContainsKey(product.Name))
            {
                productsByName[product.Name] = 
                    new OrderedBag<Product>();
            }

            productsByName[product.Name].Add(product);
        }

        private static void AddProductByProducer(Product product)
        {
            if (!productsByProducer.ContainsKey(product.Producer))
            {
                productsByProducer[product.Producer] = 
                    new OrderedBag<Product>();
            }

            productsByProducer[product.Producer].Add(product);
        }

        private static void AddProductByPriceRange(Product product)
        {
            if (!productsByPriceRange.ContainsKey(product.Price))
            {
                productsByPriceRange[product.Price] =
                    new OrderedBag<Product>();
            }

            productsByPriceRange[product.Price].Add(product);
        }
        #endregion

        #region Delete Products Methods
        private static void DeleteProductsByName(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                productsByName[product.Name].RemoveAllCopies(product);
            }
        }

        private static void DeleteProductsByPriceRange(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                productsByPriceRange[product.Price].RemoveAllCopies(product);
            }
        }

        #endregion
    }

#region Product
    class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Producer.CompareTo(other.Producer) != 0)
            {
                return this.Producer.CompareTo(other.Producer);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return "{" + this.Name + ";" +
                this.Producer + ";" +
                this.Price.ToString("0.00") + "}";
        }
    }
    #endregion
}