using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Furniture.Models
{
    using System.Text.RegularExpressions;

    class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private List<IFurniture> furnitures; 

        private Regex registrationNumberPattern = new Regex("^[0-9]{10}$");

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The name of the company cannot be null, empty or have less than 5 characters");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (!registrationNumberPattern.IsMatch(value))
                {
                    throw new ArgumentException("The registration number is not in the valid format. It must be exactly 10 digits.");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (this.furnitures.Contains(furniture))
            {
                this.furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            for (int index = 0; index < this.furnitures.Count; index++)
            {
                if (this.furnitures[index].Model.ToLower() == model.ToLower())
                {
                    return this.furnitures[index];
                }
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();
            catalog.AppendFormat("{0} - {1} - {2} {3}" + Environment.NewLine,
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            var orderedFurnitures = furnitures.Select(f => f).OrderBy(f => f.Price).ThenBy(f => f.Model);

            catalog.Append(String.Join(Environment.NewLine, orderedFurnitures));
            return catalog.ToString();
        }
    }
}
