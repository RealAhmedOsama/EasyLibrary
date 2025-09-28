namespace EasyLibrary.Core.Models;

public class BookRateDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public int Rate { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public BookDto Book { get; set; }
    public MemberDto Member { get; set; }
}