using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Contracts
{
    public interface IOrderService
    {

        List<OrderDetails> GetOrders(int userDetailsID);
        bool SaveOrder(int userDetailsID, OrderDetails orderDetails);
    }
}
