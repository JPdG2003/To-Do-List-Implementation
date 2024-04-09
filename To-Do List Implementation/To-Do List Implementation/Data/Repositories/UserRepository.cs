using Microsoft.EntityFrameworkCore;
using To_Do_List_Implementation.Data.Interfaces;
using To_Do_List_Implementation.Model;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _todoContext;

        public UserRepository (TodoContext todoContext)
        {
           _todoContext = todoContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _todoContext.AddAsync(user);
            await _todoContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await
                _todoContext.Users
                .ToListAsync();
        }

        public Task<User?> GetUserByIdAsync (int id)
        {
            return _todoContext.Users
                .FirstOrDefaultAsync(x => x.id_user == id);
        }
    }
}
