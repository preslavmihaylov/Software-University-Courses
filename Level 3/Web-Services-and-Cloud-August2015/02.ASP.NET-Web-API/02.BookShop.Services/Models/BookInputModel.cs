namespace _01._2.BookShop.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BookInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? Copies { get; set; }

        [Required]
        public int? AuthorId { get; set; }

        public string Edition { get; set; }

        public string Categories { get; set; }
    }
}