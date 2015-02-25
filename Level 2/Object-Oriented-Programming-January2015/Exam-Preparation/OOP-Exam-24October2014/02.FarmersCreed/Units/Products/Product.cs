namespace FarmersCreed.Units
{
    using System;
    using Enumerations;
    using Products;

    public class Product : GameObject, IProduct, ICloneable
    {
        private int quantity;
        private ProductType productType;

        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                this.quantity = value;
            }
        }

        public ProductType ProductType
        {
            get { return this.productType; }
            set { this.productType = value; }
        }

        public override string ToString()
        {
            // , Quantity: (Quantity), Product Type: (ProductType), Food Type: (FoodType), Health Effect: (HealthEffect)
            return base.ToString() +
                   string.Format(", Quantity: {0}, Product Type: {1}",
                                    this.Quantity, this.ProductType);
        }

        public virtual object Clone()
        {
            return new Product(this.Id, this.ProductType, this.Quantity);
        }
    }
}
