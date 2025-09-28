using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.DAL.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    // User: Id, Username, Password, Email,CreatedOn,IsActive
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)] public string Username { get; set; }

    [Required]
    [MaxLength(255)] public string Password { get; set; }

    [Required]
    [MaxLength(100)] public string Email { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation properties
    public virtual ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();
}