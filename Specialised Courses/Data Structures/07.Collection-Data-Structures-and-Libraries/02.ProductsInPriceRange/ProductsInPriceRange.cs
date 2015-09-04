namespace _02.ProductsInPriceRange
{
    using System;
    using System.IO;
    using Wintellect.PowerCollections;

    class ProductsInPriceRange
    {
        private const string ProductsFile = "../../products.txt";

        static void Main()
        {
            StreamReader reader = new StreamReader(ProductsFile);
            OrderedMultiDictionary<double, string> multiDict = new OrderedMultiDictionary<double, string>(true);

            string currentLine = reader.ReadLine();

            while (currentLine != null)
            {
                string[] productParameters = currentLine.Split(' ');
                string productName = productParameters[0];
                double price = double.Parse(productParameters[1]);

                multiDict[price].Add(productName);

                currentLine = reader.ReadLine();
            }

            Console.Write("Insert price range: ");
            string[] priceRangeParameters = Console.ReadLine().Split(' ');

            double start = double.Parse(priceRangeParameters[0]);
            double end = double.Parse(priceRangeParameters[1]);

            var range = multiDict.Range(start, true, end, true);

            foreach (var price in range)
            {
                foreach (var product in price.Value)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}