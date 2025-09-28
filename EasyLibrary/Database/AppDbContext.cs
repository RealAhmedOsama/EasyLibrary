using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.DAL.Database;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<BookRate> BookRates { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
    public DbSet<ReservationTransaction> ReservationTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=AHMED-OSAMA\\SQLEXPRESS;Initial Catalog=EasyLibrary;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}