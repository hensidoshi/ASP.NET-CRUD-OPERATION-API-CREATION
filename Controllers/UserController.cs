using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop_APICreation.Data;

namespace CoffeeShop_APICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.SelectAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.SelectByPK(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var isDeleted = _userRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserModel user)
        {
            if (user == null)
                return BadRequest();

            bool isInserted = _userRepository.Insert(user);
            if (isInserted)
                return Ok(new { Message = "User inserted successfully!" });

            return StatusCode(500, "An error occurred while inserting the user");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            if (user == null || id != user.UserID)
                return BadRequest();

            var isUpdated = _userRepository.Update(user);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }
    }
}
