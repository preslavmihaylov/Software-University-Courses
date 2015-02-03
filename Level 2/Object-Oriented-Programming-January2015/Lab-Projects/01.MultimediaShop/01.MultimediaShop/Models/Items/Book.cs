using System;
using System.Collections.Generic;

namespace MultimediaShop.Models.Items
{
    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, List<string> genres) 
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genre)
            : base(id, title, price)
        {
            this.Author = author;
            this.Genres.Add(genre);
        }

        public string Author 
        {
            get
            {
                return this.author;
            }
            private set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The author cannot be empty.");
                }
                this.author = value;
            }
        }
    }
}
