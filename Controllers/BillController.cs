using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop_APICreation.Data;

namespace CoffeeShop_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillRepository _billRepository;
        public BillController(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [HttpGet]
        public IActionResult GetAllBills()
        {
            var bills = _billRepository.SelectAll();
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public IActionResult GetBillById(int id)
        {
            var bill = _billRepository.SelectByPK(id);
            if (bill == null)
            {
                return NotFound();
            }
            return Ok(bill);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBill(int id)
        {
            var isDeleted = _billRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertBill([FromBody] BillModel bill)
        {
            if (bill == null)
                return BadRequest();

            bool isInserted = _billRepository.Insert(bill);
            if (isInserted)
                return Ok(new { Message = "Bill inserted successfully!" });

            return StatusCode(500, "An error occurred while inserting the bill");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBill(int id, [FromBody] BillModel bill)
        {
            if (bill == null || id != bill.BillID)
                return BadRequest();

            var isUpdated = _billRepository.Update(bill);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("Orders")]
        public IActionResult OrderDropDown()
        {
            var orders = _billRepository.GetOrders();
            if (!orders.Any())
                return NotFound("No users found.");

            return Ok(orders);
        }

        [HttpGet("Users")]
        public IActionResult UserDropDown()
        {
            var users = _billRepository.GetUsers();
            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }
    }
}
