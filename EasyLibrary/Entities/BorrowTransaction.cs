using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLibrary.DAL.Entities;

public class BorrowTransaction
{
    // BorrowTransaction: Id, BookId, MemberId, BorrowDate, DueDate, ReturnDate,CreatedOn,IsActive
    [Key]
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public int MemberId { get; set; }

    [Required]
    public DateTime BorrowDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation properties
    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey(nameof(MemberId))]
    public virtual Member Member { get; set; } = null!;
}