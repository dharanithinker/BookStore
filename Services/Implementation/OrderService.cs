using BookStore.Entities;
using BookStore.Helpers;
using BookStore.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class OrderService : IOrderService
    {
        public List<OrderDetails> GetOrders(int userDetailsID)
        {
            return DBHelper.GetOrders(userDetailsID);
        }

        public bool SaveOrder(int userDetailsID, OrderDetails orderDetails)
        {
            return DBHelper.SaveOrder(userDetailsID, orderDetails);
        }
    }
}
