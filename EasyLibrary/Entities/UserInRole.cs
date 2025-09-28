using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.DAL.Entities;

[Index(nameof(UserId), nameof(RoleId), IsUnique = true)]
public class UserInRole
{
    [Key] public int Id { get; set; }

    // UserInRole: UserId, RoleId,CreatedOn,IsActive
    [Required]
    public int UserId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;
}