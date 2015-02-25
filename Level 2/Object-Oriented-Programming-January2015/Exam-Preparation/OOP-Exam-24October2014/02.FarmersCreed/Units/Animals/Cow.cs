namespace FarmersCreed.Units.Animals
{
    using System;
    using Enumerations;
    using Interfaces;
    using Products;

    public class Cow : Animal
    {
        private const int BaseHealth = 15;
        private const int BaseProductionQuantity = 6;
        private const int BaseProductHealthBonus = 4;

        public Cow(string id)
            : base(
                id,
                BaseHealth,
                BaseProductionQuantity,
                new Food(id + "Product", ProductType.Milk, FoodType.Organic, BaseProductionQuantity, BaseProductHealthBonus))
        {
        }

        public override Product GetProduct()
        {
            if (this.Health > 0 && this.IsAlive)
            {
                this.Health -= 2;
                return base.GetProduct();
            }
            else
            {
                throw new ArgumentException("Cannot produce from an animal that is dead.");
            }
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic)
            {
                this.Health += food.HealthEffect * quantity;
            }
            else if (food.FoodType == FoodType.Meat)
            {
                this.Health -= food.HealthEffect * quantity;
            }
        }
    }
}
