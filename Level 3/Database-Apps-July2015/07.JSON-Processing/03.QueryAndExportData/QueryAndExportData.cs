using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using _01.ProductsShop.Context;
using Formatting = Newtonsoft.Json.Formatting;

class QueryAndExportData
{
    static void Main()
    {
        /*
         * Query 1 - Products In Range
         * 
         * Get all products in a specified price range (e.g. 500 to 1000) which have no buyer. 
         * Order them by price (from lowest to highest). 
         * Select only the product name, price and the full name of the seller.
         * 
         */

        ProductShopContext context = new ProductShopContext();

        ExportProductsInRangeToJSON(500, 1000, "../../01.products-in-range.json", context);

        /*
         * Query 2 - Successfully Sold Products
         * 
         * Get all users who have at least 1 sold item with a buyer. 
         * Order them by last name, then by first name. 
         * Select the person's first and last name. 
         * For each of the sold products (products with buyers), 
         * select the product's name, price and the buyer's first and last name.
         * Export the result to JSON.
         * 
         */

        ExportSuccessfullySoldProductsToJSON("../../02.successfully-sold-products.json", context);

        /*
         * Query 3 - Categories By Products Count
         * 
         * Get all categories.
         * Order them by the number of products in that category (a product can be in many categories). 
         * For each category select its name, the number of products, the average price of those products 
         * and the total revenue (total price sum) of those products (regardless if they have a buyer or not).
         * 
         */

        ExportCategoriesWithProductsCountToJSON("../../03.categories-with-products-count.json", context);

        /*
         * Query 4 - Users and Products
         * 
         * Get all users who have at least 1 sold product. 
         * Order them by the number of sold products (from highest to lowest), 
         * then by last name (ascending). 
         * Select only their first and last name, age and for each product - name and price.
         * Export the results to XML. 
         * 
         */

        ExportUsersAndSoldProductsToXML("../../04.users-and-products.xml", context);
    }

    static void ExportProductsInRangeToJSON(decimal start, decimal end, string filename, ProductShopContext context)
    {
        var products = context.Products
            .Where(p => p.Price >= start && p.Price <= end && p.Buyer == null)
            .Include(p => p.Seller.FirstName)
            .Include(p => p.Seller.LastName)
            .Select(p => new
            {
                Name = p.Name,
                Price = p.Price,
                FullName = p.Seller.FirstName + " " + p.Seller.LastName
            }).ToList();

        var json = JsonConvert.SerializeObject(products, Formatting.Indented);

        WriteJSONToFile(filename, json);
    }

    private static void ExportSuccessfullySoldProductsToJSON(string filename, ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.Products.Any(p => p.Buyer != null))
            .Include(u => u.Products)
            .Select(u => new
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.Products
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
            }).ToList();

        var json = JsonConvert.SerializeObject(users, Formatting.Indented);

        WriteJSONToFile(filename, json);
    }

    private static void ExportCategoriesWithProductsCountToJSON(string filename, ProductShopContext context)
    {
        var categories = context.Categories
            .OrderByDescending(c => c.Products.Count)
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.Products.Count,
                AveragePrice = c.Products.Average(p => (decimal?)p.Price),
                TotalRevenue = c.Products.Sum(p => (decimal?)p.Price)
            }).ToList();

        var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

        WriteJSONToFile(filename, json);
    }

    private static void ExportUsersAndSoldProductsToXML(string filename, ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.Products.Any(p => p.Buyer != null))
            .Include(u => u.Products)
            .Select(u => new
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = u.Products
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
            }).ToList();

        var settings = new XmlWriterSettings();
        settings.ConformanceLevel = ConformanceLevel.Document;
        settings.Encoding = Encoding.UTF8;
        settings.OmitXmlDeclaration = false;
        settings.Indent = true;

        XmlWriter writer = XmlWriter.Create(filename, settings);

        writer.WriteStartDocument();
        writer.WriteStartElement("users");
        writer.WriteAttributeString("count", users.Count.ToString());

        foreach (var user in users)
        {
            writer.WriteStartElement("user");

            if (user.FirstName != null)
            {
                writer.WriteAttributeString("first-name", user.FirstName);
            }

            if (user.LastName != null)
            {
                writer.WriteAttributeString("last-name", user.LastName);
            }

            if (user.Age != null)
            {
                writer.WriteAttributeString("age", user.Age.ToString());
            }

            writer.WriteStartElement("sold-products");
            writer.WriteAttributeString("count", user.SoldProducts.Count().ToString());

            foreach (var soldProduct in user.SoldProducts)
            {
                writer.WriteStartElement("product");
                if (soldProduct.Name != null)
                {
                    writer.WriteAttributeString("name", soldProduct.Name);
                }

                writer.WriteAttributeString("price", soldProduct.Price.ToString());

                // product
                writer.WriteEndElement();
            }

            // sold-products
            writer.WriteEndElement();

            // user
            writer.WriteEndElement();
        }

        // users
        writer.WriteEndElement();

        writer.WriteEndDocument();
        writer.Close();
    }

    private static void WriteJSONToFile(string filename, string json)
    {
        StreamWriter writer = new StreamWriter(filename);
        writer.Write(json);
        writer.Close();
    }
}