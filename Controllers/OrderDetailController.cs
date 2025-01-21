using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop_APICreation.Data;

namespace CoffeeShop_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailRepository _orderDetailRepository;
        public OrderDetailController(OrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            var orderDetails = _orderDetailRepository.SelectAll();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var orderDetail = _orderDetailRepository.SelectByPK(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var isDeleted = _orderDetailRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertOrderDetail([FromBody] OrderDetailModel orderDetail)
        {
            if (orderDetail == null)
                return BadRequest();

            bool isInserted = _orderDetailRepository.Insert(orderDetail);
            if (isInserted)
                return Ok(new { Message = "Order detail inserted successfully!" });

            return StatusCode(500, "An error occurred while inserting the order detail");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetailModel orderDetail)
        {
            if (orderDetail == null || id != orderDetail.OrderDetailID)
                return BadRequest();

            var isUpdated = _orderDetailRepository.Update(orderDetail);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("Orders")]
        public IActionResult OrderDropDown()
        {
            var orders = _orderDetailRepository.GetOrders();
            if (!orders.Any())
                return NotFound("No users found.");

            return Ok(orders);
        }

        [HttpGet("Products")]
        public IActionResult ProductDropDown()
        {
            var products = _orderDetailRepository.GetProducts();
            if (!products.Any())
                return NotFound("No users found.");

            return Ok(products);
        }

        [HttpGet("Users")]
        public IActionResult UserDropDown()
        {
            var users = _orderDetailRepository.GetUsers();
            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }
    }
}
