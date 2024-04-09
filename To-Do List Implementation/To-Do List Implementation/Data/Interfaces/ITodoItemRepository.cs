using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Data.Interfaces
{
    public interface ITodoItemRepository 
    {
        Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem);
        Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync();
        Task<IEnumerable<TodoItem>> GetItemsByUserId(int userId);
        Task<TodoItem?> GetTodoItemByIdAsync(int id);
    }
}
