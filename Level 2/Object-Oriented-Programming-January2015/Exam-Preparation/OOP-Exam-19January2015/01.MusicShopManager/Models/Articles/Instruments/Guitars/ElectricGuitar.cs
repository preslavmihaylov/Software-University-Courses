namespace MusicShop.Models.Articles.Instruments.Guitars
{
    using System;
    using MusicShopManager.Interfaces;

    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(
            string make,
            string model,
            decimal price,
            string color,
            string bodyWood,
            string fingerboardWood,
            int numberOfAdapters,
            int numberOfFrets)
            : base(make, model, price, color, true, bodyWood, fingerboardWood, 6)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get
            {
                return this.numberOfAdapters;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of adapters must be non-negative.");
                }
                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get
            {
                return this.numberOfFrets;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of frets must be positive.");
                }
                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(Environment.NewLine + 
                                 "Adapters: {0}" + Environment.NewLine +
                                 "Frets: {1}",
                                 this.NumberOfAdapters,
                                 this.NumberOfFrets);
        }
    }
}
