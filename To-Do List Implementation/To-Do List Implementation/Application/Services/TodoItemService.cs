using To_Do_List_Implementation.Application.Interfaces;
using To_Do_List_Implementation.Data.Interfaces;
using To_Do_List_Implementation.Model;
using To_Do_List_Implementation.Model.DTOs;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Application.Services
{
    public class TodoItemService : ITodoItemService 
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IUserRepository _userRepository;

        public TodoItemService (ITodoItemRepository todoItemRepository, IUserRepository userRepository)
        {
            _todoItemRepository = todoItemRepository;
            _userRepository = userRepository;
        }

        public async Task<TodoItem?> CreateTodoItem(int userId, TodoItemDto itemDto)
        {
            var checkUser = await _userRepository.GetUserByIdAsync(userId);                   //Making sure the userId is actually valid.
            if (checkUser == null)
            {
                return null;
            }
            var item = new TodoItem
            {
                title = itemDto.title,
                description = itemDto.description,
                UserId = checkUser.id_user,
            };
            await _todoItemRepository.CreateTodoItemAsync(item);
            return item;
        }

        public async Task<IEnumerable<TodoItem>?> GetAllItems()
        {
            var items = await _todoItemRepository.GetAllTodoItemsAsync();
            if (!items.Any())
            {
                return null;
            }
            return items;
        }

        public async Task<IEnumerable<TodoItem>?> GetItemsByUserId(int userId)
        {
            var items = await _todoItemRepository.GetItemsByUserId(userId);
            if (!items.Any())
            {
                return null;
            }
            return items;
        }

        public async Task<TodoItem?> GetItemById(int id)
        {
            var item = await _todoItemRepository.GetTodoItemByIdAsync(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }


        //public async Task<bool> CheckIfUserExistsAsync(int id)
        //{
        //    var result = false;
        //    var findUser = await _todoContext.Users.FirstOrDefaultAsync(u => u.id_user == id);

        //    if (findUser == null)
        //    {
        //        return result;
        //    }
        //    result = true;
        //    return result;
        //}
    }
}
