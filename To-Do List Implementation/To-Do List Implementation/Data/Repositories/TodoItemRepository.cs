using Microsoft.EntityFrameworkCore;
using To_Do_List_Implementation.Data.Interfaces;
using To_Do_List_Implementation.Model;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Data.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _todoContext;

        public TodoItemRepository (TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
        {
            await _todoContext.AddAsync(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            return await
                _todoContext.TodoItems
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetItemsByUserId (int userId)
        {
            return await
                _todoContext.TodoItems
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public Task<TodoItem?> GetTodoItemByIdAsync (int id)
        {
            return _todoContext.TodoItems
                .FirstOrDefaultAsync(t => t.id_todo_item == id);
        }
    }
}
