using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities;
using BookStore.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Route("GetOrders")]
        public IActionResult GetOrders()
        {
            int userDetailsID = getUserDetailsID();
            var userOrderDetails = _orderService.GetOrders(userDetailsID);
            return Ok(userOrderDetails);
        }

        [HttpPost, Route("Order")]
        public IActionResult Order(OrderDetails orderDetails)
        {
            int userDetailsID = getUserDetailsID();
            var userOrderDetails = _orderService.SaveOrder(userDetailsID, orderDetails);
            bool isSaved = false;
            return Ok(isSaved);
        }

        private int getUserDetailsID()
        {
            var loggedUser = HttpContext.User;
            int userDetailsID = Convert.ToInt32(loggedUser.Identity.Name);
            return userDetailsID;
        }
    }
}