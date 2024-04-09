using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do_List_Implementation.Application.Interfaces;
using To_Do_List_Implementation.Model.DTOs;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("Items")]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            var getItems = await _todoItemService.GetAllItems();
            if (getItems == null)
            {
                return NotFound();
            }
            return Ok(getItems);
        }

        [HttpGet("{userId}/Items")]
        public async Task<IActionResult> GetItemsByUserIdAsync([FromRoute] int userId)
        {
            var getItems = await _todoItemService.GetItemsByUserId(userId);
            if (getItems == null)
            {
                return NotFound();
            }
            return Ok(getItems);
        }

        [HttpGet("Items/{id}")]
        public async Task<IActionResult> GetItemByIdAsync([FromRoute] int id)
        {
            var getItem = await _todoItemService.GetItemById(id);
            if (getItem == null)
            {
                return NotFound();
            }
            return Ok(getItem);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateItemAsync([FromRoute] int userId, [FromBody] TodoItemDto todoItemDto)
        {
            var createdItem = await _todoItemService.CreateTodoItem(userId, todoItemDto);
            if (createdItem == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
