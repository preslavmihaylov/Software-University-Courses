using System;
using System.Collections.Generic;

namespace MultimediaShop.Models.Items
{
    public class Movie : Item
    {
        private int length;

        public Movie(string id, string title, decimal price, int length, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Length = length;
        }

        public Movie(string id, string title, decimal price, int length, string genre)
            : base(id, title, price)
        {
            this.Genres.Add(genre);
            this.Length = length;
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The length of the video cannot be a negative number.");
                }
                this.length = value;
            }
        }
    }
}
