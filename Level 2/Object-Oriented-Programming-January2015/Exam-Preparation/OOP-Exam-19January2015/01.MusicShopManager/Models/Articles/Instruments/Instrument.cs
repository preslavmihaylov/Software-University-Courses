namespace MusicShop.Models.Articles.Instruments
{
    using System;
    using MusicShopManager.Interfaces;

    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price, string color, bool isElectronic)
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Color is required.");
                }
                this.color = value;
            }
        }

        public bool IsElectronic
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(Environment.NewLine + 
                                 "Color: {0}" + Environment.NewLine +
                                 "Electronic: {1}",
                                 this.Color, 
                                 this.IsElectronic ? "yes" : "no");
        }
    }
}
