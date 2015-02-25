namespace FarmersCreed.Units.Animals
{
    using System;
    using Enumerations;
    using Interfaces;
    using Products;

    public class Swine : Animal
    {
        private const int BaseHealth = 20;
        private const int BaseProductionQuantity = 1;
        private const int BaseProductHealthBonus = 5;

        public Swine(string id)
            : base(
                id,
                BaseHealth,
                BaseProductionQuantity,
                new Food(id + "Product", ProductType.PorkMeat, FoodType.Meat, BaseProductionQuantity, BaseProductHealthBonus))
        {
        }

        public override Product GetProduct()
        {
            if (this.IsAlive && this.Health > 0)
            {
                this.Health = 0;
                return base.GetProduct();
            }
            else
            {
                throw new ArgumentException("Cannot produce from an animal that is dead.");
            }
        }

        public override void Eat(IEdible food, int quantity)
        {
            this.Health += food.HealthEffect * 2 * quantity;
        }

        public override void Starve()
        {
            this.Health -= 3;
        }
    }
}
