using To_Do_List_Implementation.Model.DTOs;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Application.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItem> CreateTodoItem(int userId, TodoItemDto itemDto);
        Task<IEnumerable<TodoItem>?> GetAllItems();
        Task<IEnumerable<TodoItem>?> GetItemsByUserId(int userId);
        Task<TodoItem?> GetItemById(int id);
    }
}
