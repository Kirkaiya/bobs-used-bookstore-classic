using Bookstore.Domain;
using Bookstore.Domain.Offers;
using System.Collections.Generic;

namespace Bookstore.Web.ViewModel.Resale
{
    public class ResaleIndexViewModel
    {
        public List<ResaleIndexItemViewModel> Items { get; set; } = new List<ResaleIndexItemViewModel>();

        public ResaleIndexViewModel(IEnumerable<Offer> offers)
        {
            foreach (var offer in offers)
            {
                Items.Add(new ResaleIndexItemViewModel
                {
                    BookName = offer.BookName,
                    Author = offer.Author,
                    Genre = offer.Genre.Text,
                    Publisher = offer.Publisher.Text,
                    BookType = offer.BookType.Text,
                    ISBN = offer.ISBN,
                    Condition = offer.Condition.Text,
                    Price = offer.BookPrice,
                    OfferStatus = offer.OfferStatus.ToString()
                });
            }
        }
    }

    public class ResaleIndexItemViewModel
    {
        public string BookName { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string BookType { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public string Condition { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string OfferStatus { get; set; } = string.Empty;
    }
}