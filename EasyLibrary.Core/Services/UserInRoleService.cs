using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class UserInRoleService : IUserInRoleService
{
    public async Task<List<UserInRoleDto>> GetAllAsync()
    {
        await using var db = new AppDbContext();
        var userInRoles = await db.UserInRoles
            .Include(uir => uir.Role)
            .Include(uir => uir.User)
            .ToListAsync();

        return userInRoles.Select(DtoMapper.MapUserInRoleToDto).ToList();
    }

    public async Task<UserInRoleDto?> GetByIdAsync(UserInRoleDto userInRoleDto)
    {
        await using var db = new AppDbContext();
        var userInRole = await db.UserInRoles
            .Include(uir => uir.Role)
            .Include(uir => uir.User)
            .FirstOrDefaultAsync(uir => uir.Id == userInRoleDto.Id);

        return userInRole == null ? null : DtoMapper.MapUserInRoleToDto(userInRole);
    }

    public async Task<UserInRoleDto> CreateAsync(UserInRoleDto userInRoleDto)
    {
        await using var db = new AppDbContext();
        var userInRole = DtoMapper.MapDtoToUserInRole(userInRoleDto);
        userInRole.CreatedOn = DateTime.Now;
        userInRole.IsActive = true;

        db.UserInRoles.Add(userInRole);
        await db.SaveChangesAsync();

        userInRoleDto.Id = userInRole.Id;
        userInRoleDto.CreatedOn = userInRole.CreatedOn;
        userInRoleDto.IsActive = userInRole.IsActive;
        return userInRoleDto;
    }

    public async Task<UserInRoleDto> UpdateAsync(UserInRoleDto userInRoleDto)
    {
        await using var db = new AppDbContext();
        var userInRole = DtoMapper.MapDtoToUserInRole(userInRoleDto);

        db.UserInRoles.Update(userInRole);
        await db.SaveChangesAsync();

        return userInRoleDto;
    }

    public async Task<bool> DeleteAsync(UserInRoleDto userInRoleDto)
    {
        try
        {
            await using var db = new AppDbContext();
            var userInRole = DtoMapper.MapDtoToUserInRole(userInRoleDto);

            db.UserInRoles.Remove(userInRole);
            await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<UserInRoleDto>> GetUserRolesAsync(int userId)
    {
        await using var db = new AppDbContext();
        var userInRoles = await db.UserInRoles
            .Include(uir => uir.Role)
            .Include(uir => uir.User)
            .Where(uir => uir.UserId == userId && uir.IsActive)
            .ToListAsync();

        return userInRoles.Select(DtoMapper.MapUserInRoleToDto).ToList();
    }
}