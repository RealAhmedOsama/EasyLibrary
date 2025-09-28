using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.DAL.Entities;

[Index(nameof(BookId), nameof(MemberId), IsUnique = true)]
public class BookRate
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public int MemberId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rate { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey(nameof(MemberId))]
    public virtual Member Member { get; set; } = null!;
}