using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Wintellect.PowerCollections;

class OnlineMarket
{
    private const int MaxElementsCount = 10;

    private static HashSet<Product> products;
    private static Dictionary<string, SortedSet<Product>> productsByType;
    private static OrderedDictionary<double, SortedSet<Product>> productsByPrice;

    static void Main()
    {
        InitialiseData();
        ProcessInput();
    }

    static void ProcessInput()
    {
        string input = Console.ReadLine();

        while (input != "end")
        {
            string[] commandParams = input.Split(' ');
            ProcessCommand(commandParams[0], commandParams);

            input = Console.ReadLine();
        }
    }

    static void ProcessCommand(string command, string[] parameters)
    {
        switch (command)
        {
            case "add":
                string name = parameters[1];
                double price = double.Parse(parameters[2]);
                string type = parameters[3];

                AddProduct(name, price, type);
                break;
            case "filter":
                if (parameters[2] == "type")
                {
                    FilterByType(parameters[3]);
                }
                else
                {
                    double first = double.Parse(parameters[4]);

                    if (parameters[3] == "from")
                    {
                        if (parameters.Length > 5)
                        {
                            double second = double.Parse(parameters[6]);
                            FilterByPriceFromTo(first, second);
                        }
                        else
                        {
                            FilterByPriceFrom(first);
                        }
                    }
                    else
                    {
                        FilterByPriceTo(first);
                    }
                }
                break;
        }
    }

    static void FilterByPriceFromTo(double min, double max)
    {
        var view = productsByPrice.Range(min, true, max, true);
        List<Product> outputProducts = new List<Product>();

        int cnt = 0;
        foreach (var keyValue in view)
        {
            if (cnt >= MaxElementsCount)
            {
                break;
            }

            foreach (var product in keyValue.Value)
            {
                if (cnt >= MaxElementsCount)
                {
                    break;
                }

                outputProducts.Add(product);

                ++cnt;
            }
        }

        PrintListOfProducts(outputProducts);
    }

    static void FilterByPriceFrom(double min)
    {
        var view = productsByPrice.RangeFrom(min, true);
        List<Product> outputProducts = new List<Product>();

        int cnt = 0;
        foreach (var keyValue in view)
        {
            if (cnt >= MaxElementsCount)
            {
                break;
            }

            foreach (var product in keyValue.Value)
            {
                if (cnt >= MaxElementsCount)
                {
                    break;
                }

                outputProducts.Add(product);

                ++cnt;
            }
        }

        PrintListOfProducts(outputProducts);
    }

    static void FilterByPriceTo(double max)
    {
        List<Product> outputProducts = new List<Product>();

        int cnt = 0;
        foreach (var keyValue in productsByPrice)
        {
            if (keyValue.Key > max || cnt >= MaxElementsCount)
            {
                break;
            }

            foreach (var product in keyValue.Value)
            {
                if (cnt >= MaxElementsCount)
                {
                    break;
                }
                outputProducts.Add(product);
                ++cnt;
            }
        }

        PrintListOfProducts(outputProducts);
    }

    static void FilterByType(string type)
    {
        if (!productsByType.ContainsKey(type))
        {
            PrintTypeNotFoundMessage(type);
            return;
        }

        int cnt = 0;
        List<Product> outputProducts = new List<Product>();

        foreach (var product in productsByType[type])
        {
            if (cnt >= MaxElementsCount)
            {
                break;
            }

            outputProducts.Add(product);

            ++cnt;
        }

        PrintListOfProducts(outputProducts);
    }

    static void AddProduct(string name, double price, string type)
    {
        Product product = new Product()
        {
            Name = name,
            Price = price,
            Type = type
        };

        if (!products.Contains(product))
        {
            products.Add(product);
            if (!productsByPrice.ContainsKey(product.Price))
            {
                productsByPrice[product.Price] = new SortedSet<Product>();
            }

            productsByPrice[product.Price].Add(product);

            if (!productsByType.ContainsKey(product.Type))
            {
                productsByType[product.Type] = new SortedSet<Product>();
            }

            productsByType[product.Type].Add(product);

            PrintProductAddedSuccessfullyMessage(product.Name);
        }
        else
        {
            PrintDuplicateProductMessage(product.Name);
        }
    }

    #region Messages

    static void PrintListOfProducts(List<Product> outputProducts)
    {
        Console.WriteLine("Ok: {0}", string.Join(", ", outputProducts));
    }

    static void PrintTypeNotFoundMessage(string type)
    {
        Console.WriteLine("Error: Type {0} does not exists", type);
    }

    static void PrintProductAddedSuccessfullyMessage(string name)
    {
        Console.WriteLine("Ok: Product {0} added successfully", name);
    }

    static void PrintDuplicateProductMessage(string name)
    {
        Console.WriteLine("Error: Product {0} already exists", name);
    }

    #endregion

    static void InitialiseData()
    {
        products = new HashSet<Product>();
        productsByType = new Dictionary<string, SortedSet<Product>>();
        productsByPrice = new OrderedDictionary<double, SortedSet<Product>>();
    }
}

class Product : IComparable<Product>
{
    public string Name
    {
        get;
        set;
    }

    public double Price
    {
        get;
        set;
    }

    public string Type
    {
        get;
        set;
    }

    public int CompareTo(Product other)
    {
        if (this.Price.CompareTo(other.Price) == 0)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Type.CompareTo(other.Type);
            }

            return this.Name.CompareTo(other.Name);
        }

        return this.Price.CompareTo(other.Price);
    }

    public override bool Equals(object obj)
    {
        return this.Name == ((Product)obj).Name;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("{0}({1})", this.Name, this.Price);
    }
}