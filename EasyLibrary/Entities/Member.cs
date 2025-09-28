using System.ComponentModel.DataAnnotations;

namespace EasyLibrary.DAL.Entities;

public class Member
{
    // Member: Id, Name, Email, Phone, MembershipDate,CreatedOn,IsActive
    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; }

    [Required] [MaxLength(100)] public string Email { get; set; }

    [Required] [MaxLength(15)] public string Phone { get; set; }

    [Required] public DateTime MembershipDate { get; set; }

    [Required] public DateTime CreatedOn { get; set; }

    [Required] public bool IsActive { get; set; }

    // Navigation properties
    public virtual ICollection<BorrowTransaction> BorrowTransactions { get; set; } = new List<BorrowTransaction>();

    public virtual ICollection<ReservationTransaction> ReservationTransactions { get; set; } =
        new List<ReservationTransaction>();

    public virtual ICollection<BookRate> BookRates { get; set; } = new List<BookRate>();
}