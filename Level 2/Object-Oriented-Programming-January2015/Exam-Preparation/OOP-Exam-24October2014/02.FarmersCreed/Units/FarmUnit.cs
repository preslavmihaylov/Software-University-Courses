using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int productionQuantity;
        protected bool isAlive = true;
        private int health;
        private Product product;

        protected FarmUnit(string id, int health, int productionQuantity, Product product)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.Product = product;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                this.health = value;
                if (this.health <= 0)
                {
                    this.isAlive = false;
                }
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
        }

        private Product Product
        {
            get
            {
                return this.product;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The product cannot be null.");
                }
                this.product = value;
            }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;
            }
            set
            {
                this.productionQuantity = value;
            }
        }

        public virtual Product GetProduct()
        {
            return this.Product.Clone() as Product;
        }
    }
}
