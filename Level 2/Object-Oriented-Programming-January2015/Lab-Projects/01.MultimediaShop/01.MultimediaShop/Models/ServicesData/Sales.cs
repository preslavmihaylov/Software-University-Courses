using MultimediaShop.Interfaces;
using MultimediaShop.Models.Items;
using System;
using System.Text;

namespace MultimediaShop.Models.ServicesData
{
    public class Sales : ISales
    {
        private IItem item;
        private DateTime dateOfPurchase;

        public Sales(IItem item, DateTime dateOfPurchase)
        {
            this.Item = item;
            this.DateOfPurchase = dateOfPurchase;
        }

        public Sales(IItem item)
            : this(item, DateTime.Now)
        {
        }

        public IItem Item
        {
            get 
            {
                return this.item;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The Sales item cannot be null");
                }
                this.item = value;
            }
        }

        public DateTime DateOfPurchase
        {
            get 
            {
                return this.dateOfPurchase;
            }
            private set
            {
                this.dateOfPurchase = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("- Sale " + this.DateOfPurchase.ToString("dd-MM-yyyy") + Environment.NewLine);
            output.Append(this.Item.GetType().Name + " " + this.Item.Id + Environment.NewLine);
            output.Append("Title: " + this.Item.Title + Environment.NewLine);
            output.Append("Price: " + this.Item.Price + Environment.NewLine);
            output.Append("Genres: " + String.Join(", ", this.Item.Genres) + Environment.NewLine);

            if (this.Item.GetType() == typeof(Book))
            {
                output.Append("Author: " + (this.Item as Book).Author);
            }
            else if (this.Item.GetType() == typeof(Game))
            {
                output.Append("Age restriction: " + (this.Item as Game).AgeRestriction);
            }
            else if (this.Item.GetType() == typeof(Book))
            {
                output.Append("Length: " + (this.Item as Movie).Length);
            }

            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
