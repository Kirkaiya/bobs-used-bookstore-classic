using Bookstore.Domain.Books;

namespace Bookstore.Web.Areas.Admin.Models.Inventory
{
    public class InventoryDetailsViewModel
    {
        public InventoryDetailsViewModel() { }

        public InventoryDetailsViewModel(Book book)
        {
            Author = book.Author;
            BookType = book.BookType.Text;
            Condition = book.Condition.Text;
            CoverImageUrl = book.CoverImageUrl;
            Genre = book.Genre.Text;
            Id = book.Id;
            ISBN = book.ISBN;
            Name = book.Name;
            Price = book.Price;
            Publisher = book.Publisher.Text;
            Quantity = book.Quantity;
            Summary = book.Summary;
            Year = book.Year ?? 0;
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int Year { get; set; }

        public string Publisher { get; set; } = string.Empty;

        public string BookType { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string Condition { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}