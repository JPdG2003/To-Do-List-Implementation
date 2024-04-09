using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do_List_Implementation.Application.Interfaces;
using To_Do_List_Implementation.Model.DTOs;

namespace To_Do_List_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var getUsers = await _userService.GetAllUsers();
            if (getUsers == null)
            {
                return NotFound();
            }
            return Ok(getUsers);
        }

        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var getUser = await _userService.GetUserById(id);
            if (getUser == null)
            {
                return NotFound();
            }
            return Ok(getUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
        {
            var createdUser = await _userService.CreateUser(userDto);
            return Ok(createdUser);
        }
    }
}
