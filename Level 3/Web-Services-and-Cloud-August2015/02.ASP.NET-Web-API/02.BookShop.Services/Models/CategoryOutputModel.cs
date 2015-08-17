namespace _01._2.BookShop.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryOutputModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}