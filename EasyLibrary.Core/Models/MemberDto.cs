namespace EasyLibrary.Core.Models;

public class MemberDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime MembershipDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public List<BorrowTransactionDto> BorrowTransactions { get; set; }
    public List<ReservationTransactionDto> ReservationTransactions { get; set; }
    public List<BookRateDto> BookRates { get; set; }
}