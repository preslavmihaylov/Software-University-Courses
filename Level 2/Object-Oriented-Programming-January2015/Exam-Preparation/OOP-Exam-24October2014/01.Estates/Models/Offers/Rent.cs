namespace Estates.Models.Offers
{
    using System;
    using Interfaces;

    class Rent : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public Rent()
            : base(OfferType.Rent)
        {
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price per month cannot be negative.");   
                }
                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format(", Price = {0}", this.PricePerMonth);

            return base.ToString() + output;
        }
    }
}
