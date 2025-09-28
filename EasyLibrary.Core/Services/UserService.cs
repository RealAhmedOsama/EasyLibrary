using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class UserService : IUserService
{
    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        await using var db = new AppDbContext();
        var users = await db.Users
            .Include(u => u.UserInRoles.Where(uir => uir.IsActive))
            .ThenInclude(uir => uir.Role)
            .ToListAsync();

        return users.Select(DtoMapper.MapUserToDto).ToList();
    }

    public async Task<UserDto?> GetUserByIdAsync(UserDto userDto)
    {
        await using var db = new AppDbContext();
        var user = await db.Users
            .Include(u => u.UserInRoles.Where(uir => uir.IsActive))
            .ThenInclude(uir => uir.Role)
            .FirstOrDefaultAsync(u => u.Id == userDto.Id);

        return user == null ? null : DtoMapper.MapUserToDto(user);
    }

    public async Task AddUserAsync(UserDto userDto)
    {
        await using var db = new AppDbContext();
        var user = DtoMapper.MapDtoToUser(userDto);
        user.CreatedOn = DateTime.Now;
        user.IsActive = true;

        db.Users.Add(user);
        await db.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        await using var db = new AppDbContext();
        var user = DtoMapper.MapDtoToUser(userDto);

        db.Users.Update(user);
        await db.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(UserDto userDto)
    {
        await using var db = new AppDbContext();
        var user = DtoMapper.MapDtoToUser(userDto);

        db.Users.Remove(user);
        await db.SaveChangesAsync();
    }
}