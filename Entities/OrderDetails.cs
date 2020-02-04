using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public DateTime CancelledDate { get; set; }
        public Status OrderStatus { get; set; }        
        public List<Item> Items { get; set; }
        public float TotalPrice
        {
            get
            {
                float totalPrice = 0f;
                foreach (var order in Items)
                {
                    totalPrice += (order.OrderedQuantity * order.Book.Price);
                }
                return totalPrice;
            }
        }
        public float TotalDiscount
        {
            get
            {
                float totalDiscount = 0f;
                foreach (var order in Items)
                {
                    totalDiscount += (order.OrderedQuantity * order.Book.Discount);
                }
                return totalDiscount;
            }
        }
        public float FinalPrice
        {
            get { return TotalPrice - (TotalPrice * (TotalDiscount / 100)); }
        }
    }

    public enum Status
    {
        Success = 1,
        Dispatched = 2,
        Delivered = 3,
        Completed = 4,
        Cancelled = 5
    }
}
