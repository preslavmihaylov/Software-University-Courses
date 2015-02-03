using System;
using System.Collections.Generic;
using MultimediaShop.Enumerations;

namespace MultimediaShop.Models.Items
{
    public class Game : Item
    {
        private AgeRestriction ageRestriction;

        public Game(string id, string title, decimal price, List<string> genres, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price)
        {
            this.AgeRestriction = ageRestriction;
            this.Genres.Add(genre);
        }

        public AgeRestriction AgeRestriction
        {
            get
            {
                return this.ageRestriction;
            }
            set
            {
                if (value != AgeRestriction.Teen && value != AgeRestriction.Minor && value != AgeRestriction.Adult)
                {
                    throw new ArgumentException("Invalid age restriction. The value must be either Minor, Adult or Teen");
                }
                this.ageRestriction = value;
            }
        }
    }
}
