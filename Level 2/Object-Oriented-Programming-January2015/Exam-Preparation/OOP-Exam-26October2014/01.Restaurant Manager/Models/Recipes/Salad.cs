namespace RestaurantManager.Models.Recipes
{
    using System;
    using System.Text;
    using Interfaces;

    public class Salad : Meal, ISalad
    {
        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get;
            private set;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}", this.IsVegan ? "[VEGAN] " : "");
            output.Append(base.ToString());
            output.AppendFormat("Contains pasta: {0}" + Environment.NewLine, this.ContainsPasta ? "yes" : "no");

            return output.ToString();
        }
    }
}
