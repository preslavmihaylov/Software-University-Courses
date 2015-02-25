namespace Estates.Models.Estates
{
    using System;
    using Interfaces;

    abstract class Estate : IEstate
    {
        private string name;
        private double area;
        private string location;

        protected Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of the estate cannot be null or empty");
                }

                this.name = value;
            }
        }

        public EstateType Type
        {
            get;
            set;
        }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if (value < 0 || value > 10000) // Possible error
                {
                    throw new ArgumentOutOfRangeException("The area of the apartment is out of range.");
                }
                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The location of the estate cannot be null or empty");
                }
                this.location = value;
            }
        }

        public bool IsFurnished
        {
            get;
            set;
        }

        public override string ToString()
        {
            string output = string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.GetType().Name,
                this.Name,
                this.Area,
                this.Location,
                this.IsFurnished ? "Yes" : "No");

            return output;
        }
    }
}
