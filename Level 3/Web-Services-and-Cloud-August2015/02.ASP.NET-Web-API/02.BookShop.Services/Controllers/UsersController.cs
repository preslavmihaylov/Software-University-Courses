namespace _02.BookShop.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using Models;
    using _01._1.BlogSystem.Data;
    using _01._1.BlogSystem.Interfaces;
    using _01._1.BookShop.Data.Models;

    public class UsersController : ApiController
    {
        private IBookShopData data = new BookShopData();

        [EnableQuery]
        [HttpGet]
        [Route("api/users/{username}/purchases")]
        public IHttpActionResult Purchases(string username)
        {
            ApplicationUser user = this.data.Users.All().FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return this.BadRequest("There is no user with the specified username");
            }

            IQueryable<PurchaseOutputModel> purchases = user.Purchases.Select(p => new PurchaseOutputModel()
            {
                Id = p.Id,
                BookId = p.BookId,
                Price = p.Price,
                PurchaseDate = p.PurchaseDate,
                IsRecalled = p.IsRecalled
            }).AsQueryable();

            return this.Ok(purchases);
        }
    }
}