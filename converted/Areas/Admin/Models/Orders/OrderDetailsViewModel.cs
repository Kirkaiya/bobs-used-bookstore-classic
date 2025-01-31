using Bookstore.Domain.Orders;
using System;
using System.Collections.Generic;

namespace Bookstore.Web.Areas.Admin.Models.Orders
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }

        public OrderStatus SelectedOrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string AddressLine1 { get; set; } = string.Empty;

        public string AddressLine2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public decimal Subtotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Total => Subtotal + Tax;

        public List<OrderDetailsItemViewModel> Items { get; set; } = new List<OrderDetailsItemViewModel>();

        public OrderDetailsViewModel() { }

        public OrderDetailsViewModel(Order order)
        {
            OrderId = order.Id;
            CustomerName = order.Customer.FullName;
            SelectedOrderStatus = order.OrderStatus;
            AddressLine1 = order.Address.AddressLine1;
            AddressLine2 = order.Address.AddressLine2;
            City = order.Address.City;
            State = order.Address.State;
            ZipCode = order.Address.ZipCode;
            Country = order.Address.Country;
            Subtotal = order.SubTotal;
            Tax = order.Tax;
            OrderDate = order.CreatedOn;
            DeliveryDate = order.DeliveryDate;

            foreach (var orderItem in order.OrderItems)
            {
                Items.Add(new OrderDetailsItemViewModel
                {
                    Author = orderItem.Book.Author,
                    BookType = orderItem.Book.BookType.Text,
                    Condition = orderItem.Book.Condition.Text,
                    Genre = orderItem.Book.Genre.Text,
                    Name = orderItem.Book.Name,
                    Price = orderItem.Book.Price,
                    Publisher = orderItem.Book.Publisher.Text
                });
            }
        }
    }

    public class OrderDetailsItemViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string BookType { get; set; } = string.Empty;

        public string Condition { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}