namespace _01._2.BookShop.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using Models;
    using _1.BlogSystem.Data;
    using _1.BlogSystem.Interfaces;
    using _1.BookShop.Data.Models;

    public class AuthorsController : ApiController
    {
        private IBookShopData data = new BookShopData();

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Authors.All().Select(a => new AuthorOutputModel()
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName
            }));
        }

        public IHttpActionResult Get(int id)
        {
            Author author = this.data.Authors.GetById(id);

            if (author == null)
            {
                return this.BadRequest("The specified author does not exist");
            }

            AuthorOutputModel authorModel = new AuthorOutputModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return this.Ok(authorModel);
        }

        public IHttpActionResult Post([FromBody]AuthorOutputModel authorModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("The model state is invalid");
            }

            Author author = new Author()
            {
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };

            this.data.Authors.Add(author);

            this.data.SaveChanges();

            return this.Ok(new { author.Id } );
        }

        [EnableQuery]
        [HttpGet]
        [Route("api/authors/{id}/books")]
        public IHttpActionResult Books(int id)
        {
            Author author = this.data.Authors.GetById(id);

            if (author == null)
            {
                return this.BadRequest("The specified author does not exist");
            }

            return this.Ok(author.Books.Select(b => new 
            {
                Id = b.Id,
                AuthorId = author.Id,
                Copies = b.Copies,
                Description = b.Description,
                Edition = b.Edition,
                Price = b.Price,
                Title = b.Title
            }));
        }
    }
}