namespace FarmersCreed.Units.Plants
{
    using System;
    using Enumerations;

    public class TobaccoPlant : Plant
    {
        private const int BaseHealth = 12;
        private const int BaseGrowTime = 4;
        private const int BaseProductionQuantity = 10;

        public TobaccoPlant(string id)
            : base(
                id,
                BaseHealth,
                BaseProductionQuantity,
                BaseGrowTime,
                new Product(id + "Product", ProductType.Tobacco, BaseProductionQuantity))
        {
        }

        public override void Grow()
        {
            this.GrowTime -= 2;
            if (this.GrowTime <= 0)
            {
                this.hasGrown = true;
            }
        }

        public override Product GetProduct()
        {
            if (IsAlive && HasGrown)
            {
                return base.GetProduct();
            }
            else
            {
                throw new ArgumentException("Cannot produce from the tobacco plant as it is not alive or it is still growing.");
            }
        }
    }
}