namespace RestaurantManager.Models.Recipes
{
    using System;
    using Interfaces;

    public class Drink : Recipe, IDrink
    {
        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated
        {
            get;
            private set;
        }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }
            protected set
            {
                if (value > 100)
                {
                    throw new ArgumentException(); // TODO:
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }
            protected set
            {
                if (value > 20)
                {
                    throw new ArgumentException(); // TODO:
                }

                base.TimeToPrepare = value;
            }
        }

        public override string ToString()
        {
            // Carbonated: <yes / no>
            return base.ToString() + string.Format("Carbonated: {0}" + Environment.NewLine, this.IsCarbonated ? "yes" : "no");
        }
    }
}
