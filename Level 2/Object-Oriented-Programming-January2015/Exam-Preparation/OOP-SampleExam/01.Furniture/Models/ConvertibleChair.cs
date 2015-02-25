namespace FurnitureManufacturer.Models
{
    using System;

    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private decimal initialHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.initialHeight = this.Height;
        }

        public bool IsConverted
        {
            get
            {
                return isConverted;
            }
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.Height = 0.1m;
            }
            else
            {
                this.Height = initialHeight;
            }

            isConverted = !isConverted;
        }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:F2}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs,
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}
