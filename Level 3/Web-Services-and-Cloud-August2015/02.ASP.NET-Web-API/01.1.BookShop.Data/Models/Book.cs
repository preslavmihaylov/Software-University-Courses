namespace _01._1.BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Category> categories;
 
        public Book()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int AuthorId { get; set; } 

        public Author Author { get; set; }

        public string Edition { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}