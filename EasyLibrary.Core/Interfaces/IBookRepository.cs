using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetTopRatedBooksAsync(int count);
    Task<List<Book>> GetLowRatedBooksAsync(int count);
    Task<List<Book>> GetMostBorrowedBooksAsync(int count);
    Task<List<Book>> GetMostReservedBooksAsync(int count);
}