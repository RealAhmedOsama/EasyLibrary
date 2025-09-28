using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public async Task<List<Book>> GetTopRatedBooksAsync(int count)
    {
        // Explain what this LINQ query does:
        // 1. Filters active books that have at least one rating.
        // 2. Projects each book into an anonymous object containing the book and its average rating.
        // 3. Orders the results by average rating in descending order.
        return await _dbSet
            .Where(b => b.IsActive && _db.BookRates.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = _db.BookRates
                    .Where(br => br.BookId == b.Id)
                    .Average(br => br.Rate)
            })
            .OrderByDescending(x => x.AverageRating)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();
    }

    public async Task<List<Book>> GetMostBorrowedBooksAsync(int count)
    {
        // Explain what this LINQ query does:
        // 1. Filters active books.
        // 2. Projects each book into an anonymous object containing the book and its borrow count.
        // 3. Orders the results by borrow count in descending order.
        return await _dbSet
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

    public async Task<List<Book>> GetLowRatedBooksAsync(int count)
    {
        // Explain what this LINQ query does:
        // 1. Filters active books that have at least one rating.
        // 2. Projects each book into an anonymous object containing the book and its average rating.
        // 3. Orders the results by average rating in ascending order (lowest first).
        return await _dbSet
            .Where(b => b.IsActive && _db.BookRates.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = _db.BookRates
                    .Where(br => br.BookId == b.Id)
                    .Average(br => br.Rate)
            })
            .OrderBy(x => x.AverageRating)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();
    }

    public async Task<List<Book>> GetMostReservedBooksAsync(int count)
    {
        // Explain what this LINQ query does:
        // 1. Filters active books.
        // 2. Projects each book into an anonymous object containing the book and its reservation count.
        // 3. Orders the results by reservation count in descending order.
        return await _dbSet
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