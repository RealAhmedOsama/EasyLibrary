using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class UserRepository : GenericRepository<User>
{
    public async Task<List<User>> GetAllUsersWithRolesAsync()
    {
        return await _db.Users
            .Include(u => u.UserInRoles.Where(uir => uir.IsActive))
            .ThenInclude(uir => uir.Role)
            .ToListAsync();
    }

    public async Task<User?> GetUserWithRolesByIdAsync(int userId)
    {
        return await _db.Users
            .Include(u => u.UserInRoles.Where(uir => uir.IsActive))
            .ThenInclude(uir => uir.Role)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }
}