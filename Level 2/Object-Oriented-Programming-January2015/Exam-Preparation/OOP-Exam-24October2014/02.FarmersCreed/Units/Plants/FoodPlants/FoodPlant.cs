namespace FarmersCreed.Units.Plants.FoodPlants
{
    using Products;

    public abstract class FoodPlant : Plant
    {
        protected FoodPlant(string id, int health, int productionQuantity, int growTime, Food product)
            : base(id, health, productionQuantity, growTime, product)
        {
        }

        public override void Water()
        {
            this.Health++;
        }

        public override void Wither()
        {
            this.Health -= 2;
        }
    }
}
