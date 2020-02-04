using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class UserOrderDetails
    {
        public User UserDetails { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
