namespace RestaurantManager.Models.Recipes
{
    using Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan
        {
            get;
            protected set;
        }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
    }
}
