namespace FarmersCreed.Units.Plants.FoodPlants
{
    using System;
    using Enumerations;
    using Products;

    public class CherryTree : FoodPlant
    {
        private const int BaseHealth = 14;
        private const int BaseGrowTime = 3;
        private const int BaseProductionQuantity = 4;

        public CherryTree(string id)
            : base(
                id,
                BaseHealth,
                BaseProductionQuantity,
                BaseGrowTime,
                new Food(id + "Product", ProductType.Cherry, FoodType.Organic, BaseProductionQuantity, 2))
        {
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                return base.GetProduct();
            }
            else
            {
                throw new ArgumentException("Cannot produce if the plant is dead.");
            }
        }
    }
}
