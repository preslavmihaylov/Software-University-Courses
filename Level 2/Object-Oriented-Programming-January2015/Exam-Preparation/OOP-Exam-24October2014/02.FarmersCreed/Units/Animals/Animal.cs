namespace FarmersCreed.Units.Animals
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        public Animal(string id, int health, int productionQuantity, Product product)
            : base(id, health, productionQuantity, product)
        {
        }

        public abstract void Eat(IEdible food, int quantity);

        public virtual void Starve()
        {
            this.Health--;
        }

        public override string ToString()
        {
            if (this.IsAlive)
            {
                return base.ToString() + string.Format(", Health: {0}", this.Health);
            }
            else
            {
                return base.ToString() + ", DEAD";
            }
        }
    }
}
