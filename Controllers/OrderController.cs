using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop_APICreation.Data;

namespace CoffeeShop_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderRepository.SelectAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderRepository.SelectByPK(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var isDeleted = _orderRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertOrder([FromBody] OrderModel order)
        {
            if (order == null)
                return BadRequest();

            bool isInserted = _orderRepository.Insert(order);
            if (isInserted)
                return Ok(new { Message = "Order inserted successfully!" });

            return StatusCode(500, "An error occurred while inserting the order");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderModel order)
        {
            if (order == null || id != order.OrderID)
                return BadRequest();

            var isUpdated = _orderRepository.Update(order);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("Users")]
        public IActionResult UserDropDown()
        {
            var users = _orderRepository.GetUsers();
            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }

        [HttpGet("Customers")]
        public IActionResult CustomerDropDown()
        {
            var customers = _orderRepository.GetCustomers();
            if (!customers.Any())
                return NotFound("No users found.");

            return Ok(customers);
        }
    }
}