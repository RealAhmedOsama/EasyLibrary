using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IUserInRoleService
{
    Task<List<UserInRoleDto>> GetAllAsync();
    Task<UserInRoleDto?> GetByIdAsync(UserInRoleDto userInRoleDto);
    Task<UserInRoleDto> CreateAsync(UserInRoleDto userInRoleDto);
    Task<UserInRoleDto> UpdateAsync(UserInRoleDto userInRoleDto);
    Task<bool> DeleteAsync(UserInRoleDto userInRoleDto);
}