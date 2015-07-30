namespace _01.ProductsShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual User Seller { get; set; }

        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}