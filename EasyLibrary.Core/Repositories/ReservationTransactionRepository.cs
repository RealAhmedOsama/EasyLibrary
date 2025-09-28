using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class ReservationTransactionRepository : GenericRepository<ReservationTransaction>,
    IReservationTransactionRepository
{
    public async Task<List<ReservationTransaction>> SearchReservationsAsync(string memberId, string bookId)
    {
        var query = _dbSet.Include(r => r.Book)
            .Include(r => r.Member)
            .Where(r => r.IsActive);

        // Parse member ID if provided
        if (!string.IsNullOrEmpty(memberId) && int.TryParse(memberId, out var memberIdInt))
        {
            query = query.Where(r => r.MemberId == memberIdInt);
        }

        // Parse book ID if provided
        if (!string.IsNullOrEmpty(bookId) && int.TryParse(bookId, out var bookIdInt))
        {
            query = query.Where(r => r.BookId == bookIdInt);
        }

        return await query.OrderByDescending(r => r.ReservationDate).ToListAsync();
    }
}