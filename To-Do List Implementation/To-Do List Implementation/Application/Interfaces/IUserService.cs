using To_Do_List_Implementation.Model.DTOs;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDto userDto);
        Task<IEnumerable<User>?> GetAllUsers();
        Task<User?> GetUserById(int id);
    }
}
