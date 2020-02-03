using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public Status OrderStatus { get; set; }
        public User UserDetails { get; set; }
        public List<Book> Books { get; set; }
        public float TotalPrice { get; set; }
        public float TotalDiscount { get; set; }
        public float FinalPrice { get; set; }
    }

    public enum Status
    {
        Pending = 1,
        Completed = 2,
        Cancelled = 3
    }
}
