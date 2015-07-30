namespace _01.ProductsShop.Context
{
    using System.Data.Entity;
    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("ProductShop")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany();

            modelBuilder.Entity<Product>()
                        .HasRequired<User>(p => p.Seller)
                        .WithMany(u => u.Products);
        }
    }
}
