using MultimediaShop.Enumerations;
using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;

namespace MultimediaShop.Models.Items
{
    public abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;
        private List<string> genres;

        public Item(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.Genres = new List<string>();
        }

        public Item(string id, string title, decimal price, List<string> genres)
            : this(id, title, price)
        {
            this.Genres = genres;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentException("The id must be a non-empty string containing atleast 4 digits");
                }
                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title cannot be empty");
                }
                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cannot be a negative number");
                }
                this.price = value;
            }
        }

        public List<string> Genres
        {
            get 
            {
                return this.genres;
            }
            private set
            {
                this.genres = value;
            }
        }

        public static IItem Parse(string[] input)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            for (int index = 3; index < input.Length; index++)
            {
                string[] splittedParams = input[index].Split('=');
                keyValuePairs[splittedParams[0]] = splittedParams[1];
            }

            string id = keyValuePairs["id"];
            string title = keyValuePairs["title"];
            decimal price = Decimal.Parse(keyValuePairs["price"]);
            string genre = keyValuePairs["genre"];

            IItem item;

            switch (input[1])
            {
                case "book":
                    string author = keyValuePairs["author"];

                    item = new Book(id, title, price, author, genre);
                    break;
                case "movie":
                    int length = int.Parse(keyValuePairs["length"]);

                    item = new Movie(id, title, price, length, genre);
                    break;
                case "game":
                    if (keyValuePairs.ContainsKey("ageRestriction"))
                    {
                        AgeRestriction restriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), keyValuePairs["ageRestriction"]);
                        item = new Game(id, title, price, genre, restriction);
                    }
                    else
                    {
                        item = new Game(id, title, price, genre);
                    }
                    break;
                default:
                    throw new ArgumentException("There is no such item");
            }

            return item;
        }
    }
}
