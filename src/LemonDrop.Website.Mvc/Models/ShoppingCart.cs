using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LemonDrop.Website.Mvc.Models
{
    public class ShoppingCart
    {
        private readonly List<OrderLine> _orderLines = new List<OrderLine>();

        [DisplayName("Total Price")]
        public decimal Price => _orderLines.Sum(li => li.Price);

        public int Count => _orderLines.Sum(li => li.Quantity);

        public IEnumerable<OrderLine> Lines => _orderLines;

        public void AddLineItem(OrderLine lineItem)
        {
            _orderLines.Add(lineItem);
        }

        public void RemoveLineItem(int bookId)
        {
            _orderLines.Remove(_orderLines.FirstOrDefault(li => li.Book.Id == bookId));
        }
    }

    public class OrderLine
    {
        public virtual Book Book { get; set; }

        public int BookId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Quantity * Book.Price;
    }

    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Price => OrderLines.Sum(ol => ol.Price);
        public List<OrderLine> OrderLines { get; set; }
    }
}