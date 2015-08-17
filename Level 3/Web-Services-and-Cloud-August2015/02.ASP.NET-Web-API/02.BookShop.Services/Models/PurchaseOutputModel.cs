namespace _02.BookShop.Services.Models
{
    using System;

    public class PurchaseOutputModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsRecalled { get; set; }
    }
}