namespace Estates.Models.Estates
{
    using System;
    using Interfaces;

    class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public Garage()
            : base(EstateType.Garage)
        {
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("The width of the garage cannot be negative or above 500.");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("The height of the garage cannot be negative or above 500.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format(", Width: {0}, Height: {1}",
                this.Width, this.Height);

            return base.ToString() + output;
        }
    }
}
