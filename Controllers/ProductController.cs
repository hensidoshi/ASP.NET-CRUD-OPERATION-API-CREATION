using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop_APICreation.Data;

namespace CoffeeShop_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.SelectAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.SelectByPK(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted = _productRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] ProductModel product)
        {
            if (product == null)
                return BadRequest();

            bool isInserted = _productRepository.Insert(product);
            if (isInserted)
                return Ok(new { Message = "Product inserted successfully!" });

            return StatusCode(500, "An error occurred while inserting the product");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel product)
        {
            if (product == null || id != product.ProductID)
                return BadRequest();

            var isUpdated = _productRepository.Update(product);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("Users")]
        public IActionResult UserDropDown()
        {
            var users = _productRepository.GetUsers();
            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }

    }
}
