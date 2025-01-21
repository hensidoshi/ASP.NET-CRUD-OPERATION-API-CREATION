using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop_APICreation.Data;

namespace CoffeeShop_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.SelectAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerRepository.SelectByPK(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var isDeleted = _customerRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
                return BadRequest();

            bool isInserted = _customerRepository.Insert(customer);
            if (isInserted)
                return Ok(new { Message = "Customer inserted successfully!" });

            return StatusCode(500, "An error occurred while inserting the customer");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerModel customer)
        {
            if (customer == null || id != customer.CustomerID)
                return BadRequest();

            var isUpdated = _customerRepository.Update(customer);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("Users")]
        public IActionResult UserDropDown()
        {
            var users = _customerRepository.GetUsers();
            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }
    }
}
