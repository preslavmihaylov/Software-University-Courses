namespace RestaurantManager.Models.Recipes
{
    using System;
    using System.Text;
    using Interfaces;

    class MainCourse : Meal, IMainCourse
    {
        public MainCourse(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan,
            MainCourseType type)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = type;
        }


        public MainCourseType Type
        {
            get;
            private set;
        }

        public override string ToString()
        {

            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}", this.IsVegan ? "[VEGAN] " : "");
            output.Append(base.ToString());
            output.AppendFormat("Type: {0}" + Environment.NewLine, this.Type);

            return output.ToString();
        }
    }
}
