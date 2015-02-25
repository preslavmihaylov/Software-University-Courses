namespace Estates.Models.Offers
{
    using System;
    using Interfaces;

    abstract class Offer : IOffer
    {
        private IEstate estate;

        protected Offer(OfferType type)
        {
            this.Type = type;
        }

        public IEstate Estate
        {
            get
            {
                return this.estate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The estate cannot be null.");
                }

                this.estate = value;
            }
        }

        public OfferType Type
        {
            get;
            set;
        }

        public override string ToString()
        {
            string output = string.Format("{0}: Estate = {1}, Location = {2}",
                this.GetType().Name, this.Estate.Name, this.Estate.Location);

            return output;
        }
    }
}
