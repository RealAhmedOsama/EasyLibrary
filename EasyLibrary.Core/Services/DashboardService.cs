using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class DashboardService : IDashboardService
{
    private static BookDto CreateEmptyBookDto(string title = "No rated books available")
    {
        return new BookDto
        {
            Id = 0,
            Title = title,
            Author = "",
            ISBN = "",
            PublishedYear = DateTime.Now.Year,
            CategoryId = 0,
            IsAvailable = false,
            CreatedOn = DateTime.Now,
            IsActive = false,
            Category = null,
            BorrowTransactions = new List<BorrowTransactionDto>(),
            ReservationTransactions = new List<ReservationTransactionDto>(),
            BookRates = new List<BookRateDto>()
        };
    }

    #region Simple Count Methods

    public async Task<int> GetAllBooksCountAsync()
    {
        await using var db = new AppDbContext();
        return await db.Books.CountAsync(b => b.IsActive);
    }

    public async Task<int> GetAvailableBooksCountAsync()
    {
        await using var db = new AppDbContext();
        return await db.Books.CountAsync(b => b.IsActive && b.IsAvailable);
    }

    public async Task<int> GetActiveMembersCountAsync()
    {
        await using var db = new AppDbContext();
        return await db.Members.CountAsync(m => m.IsActive);
    }

    public async Task<int> GetBorrowedBooksCountAsync(DateTime from, DateTime to)
    {
        await using var db = new AppDbContext();
        return await db.BorrowTransactions
            .CountAsync(bt => bt.IsActive && bt.BorrowDate >= from && bt.BorrowDate <= to);
    }

    #endregion

    #region Complex Data Methods

    public async Task<List<BorrowTransactionDto>> GetOverdueBooksCountAsync()
    {
        await using var db = new AppDbContext();

        var overdueTransactions = await db.BorrowTransactions
            .Include(bt => bt.Book)
            .ThenInclude(b => b!.Category)
            .Include(bt => bt.Member)
            .Where(bt => bt.IsActive && bt.ReturnDate == null && bt.DueDate < DateTime.Now)
            .OrderBy(bt => bt.DueDate)
            .ToListAsync();

        return overdueTransactions.Select(DtoMapper.MapBorrowTransactionToDto).ToList();
    }

    public async Task<List<ReservationTransactionDto>> GetPendingReservationsCountAsync()
    {
        await using var db = new AppDbContext();

        var pendingReservations = await db.ReservationTransactions
            .Include(rt => rt.Book)
            .ThenInclude(b => b!.Category)
            .Include(rt => rt.Member)
            .Where(rt => rt.IsActive && rt.ExpirationDate >= DateTime.Now)
            .OrderBy(rt => rt.ExpirationDate)
            .ToListAsync();

        return pendingReservations.Select(DtoMapper.MapReservationTransactionToDto).ToList();
    }

    public async Task<BookDto> GetTopRatedBookAsync()
    {
        await using var db = new AppDbContext();

        var topRatedBookId = await db.BookRates
            .GroupBy(br => br.BookId)
            .OrderByDescending(g => g.Average(br => br.Rate))
            .Select(g => g.Key)
            .FirstOrDefaultAsync();

        if (topRatedBookId == 0)
            return CreateEmptyBookDto();

        var topRatedBook = await db.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == topRatedBookId);

        return topRatedBook != null ? DtoMapper.MapBookToDto(topRatedBook) : CreateEmptyBookDto();
    }

    public async Task<List<BookDto>> GetMostBorrowedBooksAsync(int count)
    {
        await using var db = new AppDbContext();

        var topBookIds = await db.BorrowTransactions
            .GroupBy(bt => bt.BookId)
            .OrderByDescending(g => g.Count())
            .Take(count)
            .Select(g => new { BookId = g.Key, Count = g.Count() })
            .ToListAsync();

        if (!topBookIds.Any())
            return new List<BookDto>();

        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive && topBookIds.Select(x => x.BookId).Contains(b.Id))
            .ToListAsync();

        return books
            .Select(DtoMapper.MapBookToDto)
            .OrderByDescending(b => topBookIds.First(x => x.BookId == b.Id).Count)
            .ToList();
    }

    public async Task<List<BookDto>> GetMostReservedBooksAsync(int count)
    {
        await using var db = new AppDbContext();

        var topBookIds = await db.ReservationTransactions
            .GroupBy(rt => rt.BookId)
            .OrderByDescending(g => g.Count())
            .Take(count)
            .Select(g => new { BookId = g.Key, Count = g.Count() })
            .ToListAsync();

        if (!topBookIds.Any())
            return new List<BookDto>();

        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive && topBookIds.Select(x => x.BookId).Contains(b.Id))
            .ToListAsync();

        return books
            .Select(DtoMapper.MapBookToDto)
            .OrderByDescending(b => topBookIds.First(x => x.BookId == b.Id).Count)
            .ToList();
    }

    #endregion
}