using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(UserDto userDto);
    Task AddUserAsync(UserDto userDto);
    Task UpdateUserAsync(UserDto userDto);
    Task DeleteUserAsync(UserDto userDto);
}