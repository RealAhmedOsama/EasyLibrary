using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IRoleService
{
    Task<List<RoleDto>> GetAllRolesAsync();
    Task<RoleDto> GetRoleByIdAsync(string roleId);
    Task CreateRoleAsync(RoleDto role);
    Task<bool> UpdateRoleAsync(RoleDto role);
    Task DeleteRoleAsync(RoleDto role);
}