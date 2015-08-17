namespace _01._1.BookShop.Data.Models
{
    using System;

    public class Purchase
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsRecalled { get; set; }
    }
}