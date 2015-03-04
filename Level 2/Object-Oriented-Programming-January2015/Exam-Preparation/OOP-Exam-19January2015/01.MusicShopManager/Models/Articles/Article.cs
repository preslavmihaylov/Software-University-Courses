namespace MusicShop.Models.Articles
{
    using System;
    using MusicShopManager.Interfaces;

    public abstract class Article : IArticle
    {
        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Make is required.");
                }
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Model is required.");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The Price must be positive.");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return
                string.Format("= {0} {1} =" + Environment.NewLine + 
                              "Price: ${2:F2}",
                              this.Make,
                              this.Model,
                              this.Price);
        }
    }
}
