namespace MusicShop.Models.Articles.Instruments.Guitars
{
    using System;
    using MusicShopManager.Interfaces;

    public abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerboardWood;
        protected int numberOfStrings;

        protected Guitar(
            string make,
            string model,
            decimal price,
            string color,
            bool isElectronic, 
            string bodyWood, 
            string fingerboardWood,
            int numberOfStrings)
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            this.NumberOfStrings = numberOfStrings;
        }

        public string BodyWood
        {
            get
            {
                return this.bodyWood;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The BodyWood is required.");
                }
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get
            {
                return this.fingerboardWood;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The FingerboardWood is required.");
                }
                this.fingerboardWood = value;
            }
        }

        public virtual int NumberOfStrings
        {
            get
            {
                return this.numberOfStrings;
            }
            protected set
            {
                if (value != 6)
                {
                    throw new ArgumentException("The number of strings cannot be different than 6");
                }
                this.numberOfStrings = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(Environment.NewLine + 
                                 "Strings: {0}" + Environment.NewLine +
                                 "Body wood: {1}" + Environment.NewLine +
                                 "Fingerboard wood: {2}",
                                 this.NumberOfStrings,
                                 this.BodyWood,
                                 this.FingerboardWood);
        }
    }
}
