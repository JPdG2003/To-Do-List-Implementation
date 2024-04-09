using To_Do_List_Implementation.Application.Interfaces;
using To_Do_List_Implementation.Data.Interfaces;
using To_Do_List_Implementation.Model.DTOs;
using To_Do_List_Implementation.Model.Entities;

namespace To_Do_List_Implementation.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = new User
            {
                name = userDto.name,
                email = userDto.email,
                address = userDto.address,
            };

            await _userRepository.CreateUserAsync(user);
            return user;
        }

        public async Task<IEnumerable<User>?> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (!users.Any()) 
            {
                return null;
            }
            return users;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
