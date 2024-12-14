using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<TaskController> _logger;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
           // _logger.LogInformation("CreateUser endpoint hit.");
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (result.Succeeded)
            {
                return Ok(user);
            }
           // _logger.LogInformation("CreateUser endpoint completed.");
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetrieveUser(string id)
        {
            //_logger.LogInformation("RetrieveUser endpoint hit.");
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {

                return NotFound();
            }
            //_logger.LogInformation("RetrieveUser endpoint completed.");
            return Ok(user);
        }

        [HttpGet]
        public IActionResult ListAllUsers()
        {
            //_logger.LogInformation("ListAllUsers endpoint hit.");
            var users = _userManager.Users.ToList();
            //_logger.LogInformation("ListAllUsers endpoint completed.");
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserDetails(string id, [FromBody] User updatedUser)
        {
            //_logger.LogInformation("UpdateUserDetails endpoint hit.");
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.FullName = updatedUser.FullName;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            //_logger.LogInformation("UpdateUserDetails endpoint completed.");
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            //_logger.LogInformation("DeleteUser endpoint hit.");
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            //_logger.LogInformation("DeleteUser endpoint completed.");
            return BadRequest(result.Errors);
        }
    }

}
