using System.ComponentModel.DataAnnotations;

namespace EasyLibrary.DAL.Entities;

public class Category
{
    // Category: Id, Name, Description,CreatedOn,IsActive
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required] [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation property
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}