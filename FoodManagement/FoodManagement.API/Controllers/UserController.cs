using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FoodManagement.Services;
using Microsoft.AspNetCore.Identity.Data;
using FoodManagement.Models;

namespace FoodManagement.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(ILogin request)
        {
            User result = await _userService.LoginAsync(request.Email, request.Password);
            if (result == null) return NotFound(result);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User request)
        {
            User? result = await _userService.RegisterAsync(request.Name, request.Email, request.Password, request.Address);
            if (result == null) return NotFound(result);
            return Ok(result);
        }
        [HttpGet("checkExistence")]
        public async Task<bool> checkExistence(string username)
        {
            return await _userService.IsUserExisit(username);
        }
    }
}
