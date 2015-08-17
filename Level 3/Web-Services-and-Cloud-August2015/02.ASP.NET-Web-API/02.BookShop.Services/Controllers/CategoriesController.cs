namespace _01._2.BookShop.Services.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.OData;
    using System.Linq;
    using Models;
    using _1.BlogSystem.Data;
    using _1.BlogSystem.Interfaces;
    using _1.BookShop.Data.Models;

    public class CategoriesController : ApiController
    {
        private IBookShopData data = new BookShopData();

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Categories.All().Select(c => new CategoryOutputModel()
            {
                Id = c.Id,
                Name = c.Name
            }));
        }

        public IHttpActionResult Get(int id)
        {
            Category category = this.data.Categories.GetById(id);

            if (category == null)
            {
                return this.BadRequest("The specified category id is invalid");
            }

            return this.Ok(new CategoryOutputModel()
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        public IHttpActionResult Post(CategoryOutputModel categoryModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("The model is invalid");
            }

            Category category = new Category();

            category.Name = categoryModel.Name;

            this.data.Categories.Add(category);
            this.data.SaveChanges();

            return this.Ok(new CategoryOutputModel()
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        public IHttpActionResult Put(int id, CategoryOutputModel categoryModel)
        {
            Category category = this.data.Categories.GetById(id);

            if (category == null)
            {
                return this.BadRequest("The specified category id is invalid");
            }

            if (categoryModel.Name == null)
            {
                return this.BadRequest("The category name cannot be left empty");
            }

            category.Name = categoryModel.Name;

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Category category = this.data.Categories.GetById(id);

            if (category == null)
            {
                return this.BadRequest("The specified category id is invalid");
            }

            this.data.Categories.Delete(category);
            this.data.SaveChanges();

            return this.Ok(new
            {
                Name = category.Name
            });
        }
    }
}