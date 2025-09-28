using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLibrary.DAL.Entities;

public class ReservationTransaction
{
    // ReservationTransaction: Id, BookId, MemberId, ReservationDate, ExpirationDate,CreatedOn,IsActive

    [Key]
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public int MemberId { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [Required]
    public DateTime ExpirationDate { get; set; }

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