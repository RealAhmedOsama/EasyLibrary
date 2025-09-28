using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class DashboardRepository : GenericRepository<Book>, IDashboardRepository
{
    public async Task<int> GetAllBooksCountAsync()
    {
        return await _db.Books.CountAsync(b => b.IsActive);
    }

    public async Task<int> GetAvailableBooksCountAsync()
    {
        return await _db.Books.CountAsync(b => b.IsActive && b.IsAvailable);
    }

    public async Task<int> GetActiveMembersCountAsync()
    {
        return await _db.Members.CountAsync(m => m.IsActive);
    }

    public async Task<int> GetBorrowedBooksCountAsync(DateTime from, DateTime to)
    {
        return await _db.BorrowTransactions
            .CountAsync(bt => bt.BorrowDate >= from && bt.BorrowDate <= to && bt.IsActive);
    }

    public async Task<List<BorrowTransaction>> GetOverdueBooksAsync()
    {
        var currentDate = DateTime.Now;
        return await _db.BorrowTransactions
            .Include(bt => bt.Book)
            .Include(bt => bt.Member)
            .Where(bt => bt.IsActive && bt.ReturnDate == null && bt.DueDate < currentDate)
            .ToListAsync();
    }

    public async Task<List<ReservationTransaction>> GetPendingReservationsAsync()
    {
        return await _db.ReservationTransactions
            .Include(rt => rt.Book)
            .Include(rt => rt.Member)
            .Where(rt => rt.IsActive)
            .ToListAsync();
    }

    public async Task<Book?> GetTopRatedBookAsync()
    {
        return await _db.Books
            .Where(b => b.IsActive && _db.BookRates.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = _db.BookRates
                    .Where(br => br.BookId == b.Id)
                    .Average(br => br.Rate)
            })
            .OrderByDescending(x => x.AverageRating)
            .Select(x => x.Book)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Book>> GetMostBorrowedBooksAsync(int count)
    {
        return await _db.Books
            .Where(b => b.IsActive)
            .Select(b => new
            {
                Book = b,
                BorrowCount = _db.BorrowTransactions.Count(bt => bt.BookId == b.Id)
            })
            .OrderByDescending(x => x.BorrowCount)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();
    }

    public async Task<List<Book>> GetMostReservedBooksAsync(int count)
    {
        return await _db.Books
            .Where(b => b.IsActive)
            .Select(b => new
            {
                Book = b,
                ReservationCount = _db.ReservationTransactions.Count(rt => rt.BookId == b.Id)
            })
            .OrderByDescending(x => x.ReservationCount)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();
    }
}