using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Taiib2.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderInt _orderService;

        public OrderController(OrderInt orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{userId}")]
        public IActionResult GetOrders(int userId)
        {
            var orders = _orderService.GetOrders(userId);
            return Ok(orders);
        }

        [HttpGet("{userId}/positions")]
        public IActionResult GetOrderPositions(int userId)
        {
            var orderPositions = _orderService.GetOrderPosition(userId);
            return Ok(orderPositions);
        }

        [HttpPost]
        public IActionResult CreateOrder(int userId)
        {
            try
            {
                _orderService.CreateOrder(userId);
                return Ok("Order created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
