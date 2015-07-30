namespace _02.SeedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using Newtonsoft.Json;
    using _01.ProductsShop.Context;
    using _01.ProductsShop.Models;

    class SeedDatabase
    {
        static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ProductShopContext>());

            ProductShopContext context = new ProductShopContext();

            ImportUsersFromXML("../../users.xml", context);

            ImportCategoriesFromJSON("../../categories.json", context);

            ImportProductsFromJSON("../../products.json", context);
        }

        static void ImportCategoriesFromJSON(string filename, ProductShopContext context)
        {
            StreamReader reader = new StreamReader(filename);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(reader.ReadToEnd());
            reader.Close();

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        static void ImportProductsFromJSON(string filename, ProductShopContext context)
        {
            StreamReader reader = new StreamReader(filename);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(reader.ReadToEnd());
            reader.Close();

            Random randGenerator = new Random();
            foreach (var product in products)
            {
                if ( !(randGenerator.Next(1, 100) < 30) )
                {
                    product.Buyer = context.Users.Find(randGenerator.Next(1, context.Users.Count()));
                }

                product.Seller = context.Users.Find(randGenerator.Next(1, context.Users.Count()));

                var category = context.Categories.Find(randGenerator.Next(1, context.Categories.Count()));
                product.Categories.Add(category);

                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        static void ImportUsersFromXML(string filename, ProductShopContext context)
        {
            XmlReader reader = XmlReader.Create(filename);

            while (reader.Read())
            {
                if (reader.Name == "user")
                {
                    User user = new User();
                    if (reader.GetAttribute("first-name") != null)
                    {
                        user.FirstName = reader.GetAttribute("first-name");
                    }

                    if (reader.GetAttribute("last-name") != null)
                    {
                        user.LastName = reader.GetAttribute("last-name");
                    }

                    if (reader.GetAttribute("age") != null)
                    {
                        user.Age = int.Parse(reader.GetAttribute("age"));
                    }

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }    
        }
    }
}