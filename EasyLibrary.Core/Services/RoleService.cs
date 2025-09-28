using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Repositories;
using EasyLibrary.DAL.Database;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class RoleService : IRoleService
{
    private readonly GenericRepository<Role> _roleRepository = new();

    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        await using var db = new AppDbContext();
        var roles = await db.Roles
            .Include(r => r.UserInRoles.Where(uir => uir.IsActive))
            .ThenInclude(uir => uir.User)
            .ToListAsync();

        return roles.Select(DtoMapper.MapRoleToDto).ToList();
    }

    public async Task<RoleDto> GetRoleByIdAsync(string roleId)
    {
        if (!int.TryParse(roleId, out var id))
            return null;

        await using var db = new AppDbContext();
        var role = await db.Roles
            .Include(r => r.UserInRoles.Where(uir => uir.IsActive))
            .ThenInclude(uir => uir.User)
            .FirstOrDefaultAsync(r => r.Id == id);

        return role == null ? null : DtoMapper.MapRoleToDto(role);
    }

    public async Task CreateRoleAsync(RoleDto roleDto)
    {
        await using var db = new AppDbContext();
        var role = DtoMapper.MapDtoToRole(roleDto);
        role.CreatedOn = DateTime.Now;
        role.IsActive = true;

        db.Roles.Add(role);
        await db.SaveChangesAsync();
    }

    public async Task<bool> UpdateRoleAsync(RoleDto roleDto)
    {
        await using var db = new AppDbContext();
        var role = DtoMapper.MapDtoToRole(roleDto);

        db.Roles.Update(role);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task DeleteRoleAsync(RoleDto roleDto)
    {
        await using var db = new AppDbContext();
        var role = DtoMapper.MapDtoToRole(roleDto);

        db.Roles.Remove(role);
        await db.SaveChangesAsync();
    }
}