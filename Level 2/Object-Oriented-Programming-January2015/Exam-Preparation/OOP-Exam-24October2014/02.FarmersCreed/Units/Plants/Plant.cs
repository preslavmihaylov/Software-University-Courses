namespace FarmersCreed.Units
{
    public abstract class Plant : FarmUnit
    {
        protected bool hasGrown;

        public Plant(string id, int health, int productionQuantity, int growTime, Product product)
            : base(id, health, productionQuantity, product)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get
            {
                return this.hasGrown;
            }
        }

        public int GrowTime
        {
            get;
            protected set;
        }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health -= 1;
        }

        public virtual void Grow()
        {
            this.GrowTime--;
            if (this.GrowTime <= 0)
            {
                this.hasGrown = true;
            }
        }

        public override string ToString()
        {
            if (this.IsAlive)
            {
                return base.ToString() + string.Format(", Health: {0}, Grown: {1}", this.Health, this.HasGrown ? "Yes" : "No");
            }
            else
            {
                return base.ToString() + ", DEAD";
            }
        }
    }
}
