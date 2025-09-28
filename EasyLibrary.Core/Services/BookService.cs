using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Repositories;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class BookService : IBookService
{
    private readonly BookRepository _bookRepository = new();

    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        await using var db = new AppDbContext();
        var books = await db.Books
            .Include(b => b.Category)
            .ToListAsync();

        return books.Select(DtoMapper.MapBookToDto).ToList();
    }

    public async Task<BookDto?> GetBookByIdAsync(BookDto bookDto)
    {
        await using var db = new AppDbContext();
        var book = await db.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == bookDto.Id);

        return book == null ? null : DtoMapper.MapBookToDto(book);
    }

    public async Task AddBookAsync(BookDto bookDto)
    {
        await using var db = new AppDbContext();
        var book = DtoMapper.MapDtoToBook(bookDto);
        book.CreatedOn = DateTime.Now;
        book.IsActive = true;

        db.Books.Add(book);
        await db.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(BookDto bookDto)
    {
        await using var db = new AppDbContext();
        var book = DtoMapper.MapDtoToBook(bookDto);

        db.Books.Update(book);
        await db.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(BookDto bookDto)
    {
        await using var db = new AppDbContext();
        var book = DtoMapper.MapDtoToBook(bookDto);

        db.Books.Remove(book);
        await db.SaveChangesAsync();
    }

    public async Task<List<BookDto>> GetBooksByCategoryAsync(string category)
    {
        await using var db = new AppDbContext();
        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive && b.Category.Name.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();

        return books.Select(DtoMapper.MapBookToDto).ToList();
    }

    public async Task<List<BookDto>> GetTopRatedBooksAsync(int count)
    {
        await using var db = new AppDbContext();
        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive && db.BookRates.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = db.BookRates.Where(br => br.BookId == b.Id).Average(br => br.Rate)
            })
            .OrderByDescending(x => x.AverageRating)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();

        return books.Select(DtoMapper.MapBookToDto).ToList();
    }

    public async Task<List<BookDto>> GetMostBorrowedBooksAsync(int count)
    {
        await using var db = new AppDbContext();
        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive)
            .Select(b => new
            {
                Book = b,
                BorrowCount = db.BorrowTransactions.Count(bt => bt.BookId == b.Id)
            })
            .OrderByDescending(x => x.BorrowCount)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();

        return books.Select(DtoMapper.MapBookToDto).ToList();
    }

    public async Task<List<BookDto>> GetLowRatedBooksAsync(int count)
    {
        await using var db = new AppDbContext();
        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive && db.BookRates.Any(br => br.BookId == b.Id))
            .Select(b => new
            {
                Book = b,
                AverageRating = db.BookRates.Where(br => br.BookId == b.Id).Average(br => br.Rate)
            })
            .OrderBy(x => x.AverageRating)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();

        return books.Select(DtoMapper.MapBookToDto).ToList();
    }

    public async Task<List<BookDto>> GetMostReservedBooksAsync(int count)
    {
        await using var db = new AppDbContext();
        var books = await db.Books
            .Include(b => b.Category)
            .Where(b => b.IsActive)
            .Select(b => new
            {
                Book = b,
                ReservationCount = db.ReservationTransactions.Count(rt => rt.BookId == b.Id)
            })
            .OrderByDescending(x => x.ReservationCount)
            .Take(count)
            .Select(x => x.Book)
            .ToListAsync();

        return books.Select(DtoMapper.MapBookToDto).ToList();
    }
}