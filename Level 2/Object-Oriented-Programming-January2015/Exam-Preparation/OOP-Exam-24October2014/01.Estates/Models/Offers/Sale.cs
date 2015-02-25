namespace Estates.Models.Offers
{
    using System;
    using Interfaces;

    class Sale : Offer, ISaleOffer
    {
        private decimal price;

        public Sale()
            : base(OfferType.Sale)
        {
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
                    throw new ArgumentException("The price cannot be a negative number.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format(", Price = {0}", this.Price);

            return base.ToString() + output;
        }
    }
}
