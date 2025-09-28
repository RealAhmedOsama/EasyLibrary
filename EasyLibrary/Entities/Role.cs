using System.ComponentModel.DataAnnotations;

namespace EasyLibrary.DAL.Entities;

public class Role
{
    // Id, RoleName, Description,CreatedOn,IsActive
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string RoleName { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation properties
    public virtual ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();
}