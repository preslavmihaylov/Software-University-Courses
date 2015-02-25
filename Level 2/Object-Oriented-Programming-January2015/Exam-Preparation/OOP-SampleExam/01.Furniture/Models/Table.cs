using System;

namespace FurnitureManufacturer.Models
{
    class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Width = width;
            this.Length = length;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The length cannot be a negative number.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The length cannot be a negative number.");
                }

                this.width = value;
            }
        }


        public decimal Area
        {
            get
            {
                return this.Width * this.Length;
            }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:F2}, Length: {5}, Width: {6}, Area: {7}",
                    this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width,
                    this.Area);
        }
    }   
}