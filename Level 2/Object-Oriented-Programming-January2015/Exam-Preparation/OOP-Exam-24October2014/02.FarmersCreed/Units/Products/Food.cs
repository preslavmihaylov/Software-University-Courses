namespace FarmersCreed.Units.Products
{
    using System;
    using Enumerations;
    using Interfaces;

    public class Food : Product, IEdible
    {
        private int healthEffect;

        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.FoodType = foodType;
            this.HealthEffect = healthEffect;
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The health effect cannot be negative.");
                }
                this.healthEffect = value;
            }
        }

        public FoodType FoodType
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Food Type: {0}, Health Effect: {1}", this.FoodType, this.HealthEffect);
        }

        public override object Clone()
        {
            return new Food(this.Id, this.ProductType, this.FoodType, this.Quantity, this.HealthEffect);
        }
    }
}
