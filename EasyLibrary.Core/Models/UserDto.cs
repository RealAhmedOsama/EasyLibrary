namespace EasyLibrary.Core.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public List<UserInRoleDto> UserInRoles { get; set; }
}