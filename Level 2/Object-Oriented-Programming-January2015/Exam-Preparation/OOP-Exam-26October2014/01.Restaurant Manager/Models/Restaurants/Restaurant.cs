namespace RestaurantManager.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> recipes = new List<IRecipe>();

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
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

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Location is required");
                }
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return this.recipes;
            }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            if (this.Recipes.Contains(recipe))
            {
                this.Recipes.Remove(recipe);
            }
        }

        public string PrintMenu()
        {
            // TODO:
            StringBuilder output = new StringBuilder();

            output.AppendFormat("***** {0} - {1} *****" + Environment.NewLine, this.Name, this.Location);

            if (this.Recipes.Count == 0)
            {
                output.Append("No recipes... yet");
            }
            else
            {
                var drinks = this.Recipes.Where(d => d is IDrink).OrderBy(d => d.Name);
                var salads = this.Recipes.Where(s => s is ISalad).OrderBy(s => s.Name);
                var mainCourses = this.Recipes.Where(m => m is IMainCourse).OrderBy(m => m.Name);
                var desserts = this.Recipes.Where(d => d is IDessert).OrderBy(d => d.Name);

                if (drinks.Any())
                {
                    output.Append("~~~~~ DRINKS ~~~~~" + Environment.NewLine);
                    foreach (var drink in drinks)
                    {
                        output.Append(drink.ToString());
                    }
                    output.Remove(output.Length - 1, 1);
                }

                if (salads.Any())
                {
                    output.Append("~~~~~ SALADS ~~~~~" + Environment.NewLine);
                    foreach (var salad in salads)
                    {
                        output.Append(salad.ToString());
                    }
                    output.Remove(output.Length - 1, 1);
                }

                if (mainCourses.Any())
                {
                    output.Append("~~~~~ MAIN COURSES ~~~~~" + Environment.NewLine);
                    foreach (var mainCourse in mainCourses)
                    {
                        output.Append(mainCourse.ToString());
                    }
                    output.Remove(output.Length - 1, 1);
                }

                if (desserts.Any())
                {
                    output.Append("~~~~~ DESSERTS ~~~~~" + Environment.NewLine);
                    foreach (var dessert in desserts)
                    {
                        output.Append(dessert.ToString());
                    }
                    output.Remove(output.Length - 1, 1);
                }
                output.Remove(output.Length - 1, 1);
            }

            return output.ToString();
        }
    }
}
