using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLibrary.DAL.Entities;

public class Book
{
    // Book: Id, Title, Author, ISBN, PublishedYear, CategoryId, IsAvailable,CreatedOn,IsActive
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [MaxLength(100)]
    public string Author { get; set; }

    [Required]
    [MaxLength(13)]
    public string ISBN { get; set; }

    [Required]
    public int PublishedYear { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation property
    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;
}