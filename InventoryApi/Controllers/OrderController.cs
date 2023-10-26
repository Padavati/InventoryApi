using Inventory.BAL.Services;
using Inventory.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("GetOrders")]
        public IEnumerable<Order> GetOrders()
        {
            return _orderService.GetOrders();
        }
        [HttpGet("GetOrderById")]
        public Order GetOrderById(int OrderId)
        {
            return _orderService.GetOrderById(OrderId);
        }
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int OrderId)
        {
            _orderService.DeleteOrder(OrderId);
            return Ok("Order deleted Successfully");
        }
        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] Order order)
        {
            _orderService.UpdateOrder(order);
            return Ok("Order updated successfully");
        }
        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            _orderService.AddOrder(order);
            return Ok("Order created successfully");
        }
    }
}

