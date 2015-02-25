namespace Estates.Models.Estates
{
    using System;
    using Interfaces;

    class House : Estate, IHouse
    {
        private int floors;

        public House()
            : base(EstateType.House)
        {
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("The number of floors cannot be negative or above 10.");
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format(", Floors: {0}", this.Floors);

            return base.ToString() + output;
        }
    }
}
