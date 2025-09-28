using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class BookRateRepository : GenericRepository<BookRate>, IBookRateRepository
{
    public async Task<bool> HasMemberRatedBookAsync(Book book, Member member)
    {
        return await _dbSet.AnyAsync(br => br.BookId == book.Id && br.MemberId == member.Id);
    }

    public async Task<double?> GetAverageRatingAsync(Book book)
    {
        var ratings = await _dbSet.Where(br => br.BookId == book.Id).ToListAsync();

        if (!ratings.Any())
            return null;

        return ratings.Average(br => br.Rate);
    }

    public async Task<int?> GetLowestRatingAsync(Book book)
    {
        var ratings = await _dbSet.Where(br => br.BookId == book.Id).ToListAsync();

        if (!ratings.Any())
            return null;

        return ratings.Min(br => br.Rate);
    }

    public async Task<int?> GetHighestRatingAsync(Book book)
    {
        var ratings = await _dbSet.Where(br => br.BookId == book.Id).ToListAsync();

        if (!ratings.Any())
            return null;

        return ratings.Max(br => br.Rate);
    }

    public async Task<Book?> GetHighestRatingBookAsync()
    {
        var bookWithHighestRating = await _db.Books
            .Where(b => b.IsActive && _dbSet.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = _dbSet
                    .Where(br => br.BookId == b.Id)
                    .Average(br => br.Rate)
            })
            .OrderByDescending(x => x.AverageRating)
            .FirstOrDefaultAsync();

        return bookWithHighestRating?.Book;
    }

    public async Task<Book?> GetLowestRatingBookAsync()
    {
        var bookWithLowestRating = await _db.Books
            .Where(b => b.IsActive && _dbSet.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = _dbSet
                    .Where(br => br.BookId == b.Id)
                    .Average(br => br.Rate)
            })
            .OrderBy(x => x.AverageRating)
            .FirstOrDefaultAsync();

        return bookWithLowestRating?.Book;
    }
}