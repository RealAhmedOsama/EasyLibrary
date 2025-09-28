namespace EasyLibrary.Core.Models;

public class ReservationTransactionDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public BookDto Book { get; set; }
    public MemberDto Member { get; set; }
}