namespace EasyLibrary.Core.Models;

public class UserInRoleDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public UserDto User { get; set; }
    public RoleDto Role { get; set; }
}