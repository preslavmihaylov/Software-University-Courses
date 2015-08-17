namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _01._1.BookShop.Data;
    using _01._1.BookShop.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShopDbContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            var misho = new Author()
            {
                FirstName = "Misho",
                LastName = "Mihov"
            };

            var pesho = new Author()
            {
                FirstName = "Peter",
                LastName = "Petrov"
            };

            var minka = new Author()
            {
                FirstName = "Minka",
                LastName = "Nikolova"
            };

            var gosho = new Author()
            {
                FirstName = "Gosho",
                LastName = "Goshov"
            };

            context.Authors.Add(minka);
            context.Authors.Add(misho);
            context.Authors.Add(gosho);
            context.Authors.Add(pesho);

            var category1 = new Category()
            {
                Name = "Common"
            };

            var category2 = new Category()
            {
                Name = "Dumb"
            };

            var category3 = new Category()
            {
                Name = "Code"
            };

            var category4 = new Category()
            {
                Name = "Something"
            };

            var category5 = new Category()
            {
                Name = "Useless"
            };

            var category6 = new Category()
            {
                Name = "Useful"
            };

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.Categories.Add(category3);
            context.Categories.Add(category4);
            context.Categories.Add(category5);
            context.Categories.Add(category6);

            var book1 = new Book()
            {
                Author = misho,
                Copies = 6,
                Description = "Very cool",
                Edition = "5",
                Price = 5.50m,
                Title = "A very cool book"
            };

            var book2 = new Book()
            {
                Author = pesho,
                Copies = 5,
                Description = "Very dumb",
                Edition = "1",
                Price = 1.50m,
                Title = "A very dumb book"
            };

            var book3 = new Book()
            {
                Author = minka,
                Copies = 6,
                Description = "urrgh",
                Edition = "1",
                Price = 50.50m,
                Title = "50 shades of bla bla"
            };

            var book4 = new Book()
            {
                Author = misho,
                Copies = 4,
                Description = "True dat",
                Edition = "1",
                Price = 500.50m,
                Title = "How to understand women"
            };

            var book5 = new Book()
            {
                Author = gosho,
                Copies = 10,
                Description = "Misc",
                Edition = "2",
                Price = 14.50m,
                Title = "Kekekeke"
            };

            var book6 = new Book()
            {
                Author = pesho,
                Copies = 8,
                Description = "Reference for cs",
                Edition = "2",
                Price = 16.50m,
                Title = "How to lose at CS:GO"
            };

            var book7 = new Book()
            {
                Author = gosho,
                Copies = 8,
                Description = "How to be Gosho",
                Edition = "2",
                Price = 20.50m,
                Title = "How to be a Gosho and be awesome at it"
            };

            book1.Categories.Add(category1);
            book6.Categories.Add(category2);
            book5.Categories.Add(category5);
            book4.Categories.Add(category4);
            book3.Categories.Add(category3);
            book2.Categories.Add(category6);
            book7.Categories.Add(category5);
            book1.Categories.Add(category5);
            book3.Categories.Add(category6);
            book4.Categories.Add(category2);

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);
            context.Books.Add(book6);
            context.Books.Add(book7);
        }
    }
}
