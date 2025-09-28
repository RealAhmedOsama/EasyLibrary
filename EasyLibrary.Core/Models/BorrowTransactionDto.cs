namespace EasyLibrary.Core.Models;

public class BorrowTransactionDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public BookDto Book { get; set; }
    public MemberDto? Member { get; set; }
}