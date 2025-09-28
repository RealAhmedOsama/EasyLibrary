namespace EasyLibrary.Core.Models;

public class RoleDto
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public List<UserInRoleDto> UserInRoles { get; set; }
}