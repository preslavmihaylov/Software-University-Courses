namespace _02.BookShop.Services.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using _01._1.BookShop.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}