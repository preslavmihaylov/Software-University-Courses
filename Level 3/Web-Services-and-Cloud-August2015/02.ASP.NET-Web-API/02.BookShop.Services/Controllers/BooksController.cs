namespace _01._2.BookShop.Services.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.OData;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Models;
    using _1.BlogSystem.Data;
    using _1.BlogSystem.Interfaces;
    using _1.BookShop.Data.Models;

    public class BooksController : ApiController
    {
        private IBookShopData data = new BookShopData();

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Books.All().Select(book => new 
            {
                Id = book.Id,
                AuthorId = book.AuthorId,
                Copies = book.Copies,
                Description = book.Description,
                Edition = book.Edition,
                Price = book.Price,
                Title = book.Title,
                Categories = book.Categories.Select(c => new 
                {
                    Id = c.Id,
                    Name = c.Name
                })
            }));
        }

        public IHttpActionResult Get(int id)
        {
            Book book = this.data.Books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("The specified book does not exist");
            }

            var bookModel = new 
            {
                Id = book.Id,
                AuthorId = book.AuthorId,
                Copies = book.Copies,
                Description = book.Description,
                Edition = book.Edition,
                Price = book.Price,
                Title = book.Title,
                Categories = book.Categories.Select(c => new 
                {
                    Id = c.Id,
                    Name = c.Name
                })
            };

            return this.Ok(bookModel);
        }

        public IHttpActionResult Get(string search)
        {
            return this.Ok(this.data.Books
                .All()
                .Where(b => b.Title.ToLower().Contains(search.ToLower()))
                .Select(b => new 
                {
                    Id = b.Id,
                    Title = b.Title
                })
                .Take(10));
        }

        public IHttpActionResult Post(BookInputModel bookModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("The model is not valid");
            }

            Author bookAuthor = this.data.Authors.GetById(bookModel.AuthorId);

            if (bookAuthor == null)
            {
                return this.BadRequest("Invalid author id");
            }

            Book book = new Book()
            {
                Author = bookAuthor,
                AuthorId = bookAuthor.Id,
                Copies = Convert.ToInt32(bookModel.Copies),
                Description = bookModel.Description,
                Edition = bookModel.Edition,
                Price = Convert.ToDecimal(bookModel.Price),
                Title = bookModel.Title
            };

            if (bookModel.Categories != null)
            {
                string[] categories = bookModel.Categories.Split(',');

                for (int index = 0; index < categories.Length; index++)
                {
                    string currentCategory = categories[index].Trim();

                    Category category = this.data.Categories.All()
                        .FirstOrDefault(c => c.Name.ToLower() == currentCategory.ToLower());

                    if (category == null)
                    {
                        return this.BadRequest("Invalid category name " + currentCategory + ". ");
                    }

                    book.Categories.Add(category);
                }
            }

            this.data.Books.Add(book);
            this.data.SaveChanges();

            return this.Ok(new { book.Id });
        }

        public IHttpActionResult Put(int id, BookInputModel bookModel)
        {
            Book book = this.data.Books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("The specified book id is invalid");
            }

            if (bookModel.AuthorId != null)
            {
                Author author = this.data.Authors.GetById(bookModel.AuthorId);

                if (author == null)
                {
                    return this.BadRequest("Invalid author id");
                }

                book.AuthorId = author.Id;
            }

            if (bookModel.Title != null)
            {
                book.Title = bookModel.Title;
            }

            if (bookModel.Price != null)
            {
                book.Price = Convert.ToDecimal(bookModel.Price);
            }

            if (bookModel.Copies != null)
            {
                book.Copies = Convert.ToInt32(bookModel.Copies);
            }

            if (bookModel.Description != null)
            {
                book.Description = bookModel.Description;
            }

            if (bookModel.Edition != null)
            {
                book.Edition = bookModel.Edition;
            }

            if (bookModel.Categories != null)
            {
                string[] categories = bookModel.Categories.Split(',');

                for (int index = 0; index < categories.Length; index++)
                {
                    string currentCategory = categories[index].Trim();

                    Category category = this.data.Categories.All()
                        .FirstOrDefault(c => c.Name.ToLower() == currentCategory.ToLower());

                    if (category == null)
                    {
                        return this.BadRequest("Invalid category name " + currentCategory + ". ");
                    }

                    if (!book.Categories.Contains(category))
                    {
                        book.Categories.Add(category);
                    }
                }
            }

            this.data.SaveChanges();

            return this.Ok();
        }
        
        public IHttpActionResult Delete(int id)
        {
            Book book = this.data.Books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("The specified book id is invalid");
            }

            this.data.Books.Delete(book);
            this.data.SaveChanges();

            return this.Ok(new
            {
                AuthorId = book.AuthorId,
                Copies = book.Copies,
                Description = book.Description,
                Edition = book.Edition,
                Price = book.Price,
                Title = book.Title
            });
        }

        [Authorize]
        [HttpPut]
        [Route("api/books/buy/{id}")]
        public IHttpActionResult Buy(int id)
        {
            Book book = this.data.Books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("The specified book id is invalid");
            }

            string userId = this.RequestContext.Principal.Identity.GetUserId();
            ApplicationUser currentUser = this.data.Users.GetById(userId);

            if (book.Copies <= 0)
            {
                return this.BadRequest("The specified book doesn't have enough copies left");
            }

            Purchase purchase = new Purchase()
            {
                Book = book,
                ApplicationUser = currentUser,
                Price = book.Price,
                PurchaseDate = DateTime.Now,
                IsRecalled = false
            };

            book.Copies -= 1;
            
            currentUser.Purchases.Add(purchase);
            this.data.Purchases.Add(purchase);
            this.data.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("api/books/recall/{id}")]
        public IHttpActionResult Recall(int id)
        {
            Book book = this.data.Books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("The specified book id is invalid");
            }

            string userId = this.RequestContext.Principal.Identity.GetUserId();
            ApplicationUser currentUser = this.data.Users.GetById(userId);

            Purchase purchase = this.data.Purchases.All().FirstOrDefault(p => p.Book.Id == book.Id);
            
            if (purchase == null)
            {
                return this.BadRequest("There is no purchase with the specified book");
            }

            if (purchase.PurchaseDate - DateTime.Now > new TimeSpan(30, 0, 0, 0))
            {
                return this.BadRequest("Cannot recall a purchase after 30 days have passed");
            }

            purchase.IsRecalled = true;
            book.Copies += 1;
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}