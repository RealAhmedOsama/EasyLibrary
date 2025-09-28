using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task<BookDto?> GetBookByIdAsync(BookDto bookDto);
    Task AddBookAsync(BookDto bookDto);
    Task UpdateBookAsync(BookDto bookDto);
    Task DeleteBookAsync(BookDto bookDto);
    Task<List<BookDto>> GetBooksByCategoryAsync(string category);
    Task<List<BookDto>> GetTopRatedBooksAsync(int count);
    Task<List<BookDto>> GetLowRatedBooksAsync(int count);
    Task<List<BookDto>> GetMostBorrowedBooksAsync(int count);
    Task<List<BookDto>> GetMostReservedBooksAsync(int count);
}