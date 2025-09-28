namespace EasyLibrary.Core.Models;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublishedYear { get; set; }
    public int CategoryId { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public CategoryDto Category { get; set; }
    public List<BorrowTransactionDto> BorrowTransactions { get; set; }
    public List<ReservationTransactionDto> ReservationTransactions { get; set; }
    public List<BookRateDto> BookRates { get; set; }
}