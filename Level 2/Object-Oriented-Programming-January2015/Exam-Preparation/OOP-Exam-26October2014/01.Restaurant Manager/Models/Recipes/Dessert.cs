namespace RestaurantManager.Models.Recipes
{
    using Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan = false)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }


        public bool WithSugar
        {
            get;
            private set;
        }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", 
                !this.WithSugar ? "[NO SUGAR] " : "",
                this.IsVegan ? "[VEGAN] " : "") 
                + base.ToString();
        }
    }
}
