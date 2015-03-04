namespace RestaurantManager.Models.Recipes
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private MetricUnit unit;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.Unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Name is required");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The Price must be positive");
                }
                this.price = value;
            }
        }

        public virtual int Calories
        {
            get
            {
                return this.calories;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The Calories must be positive");
                }
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The QuantityPerServing must be positive");
                }
                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit
        {
            get;
            private set;
        }

        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The TimeToPrepare must be positive");
                }
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("==  {0} == ${1:F2}" + Environment.NewLine, this.Name, this.Price);
            output.AppendFormat("Per serving: {0} {1}, {2} kcal" + Environment.NewLine,
                this.QuantityPerServing,
                this.Unit == MetricUnit.Grams ? "g" : "ml",
                this.Calories);

            output.AppendFormat("Ready in {0} minutes" + Environment.NewLine, this.TimeToPrepare);

            return output.ToString();
        }
    }
}
