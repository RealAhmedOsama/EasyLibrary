using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IDashboardService
{
    Task<int> GetAllBooksCountAsync();
    Task<int> GetAvailableBooksCountAsync();
    Task<int> GetActiveMembersCountAsync();
    Task<int> GetBorrowedBooksCountAsync(DateTime from, DateTime to);
    Task<List<BorrowTransactionDto>> GetOverdueBooksCountAsync();
    Task<List<ReservationTransactionDto>> GetPendingReservationsCountAsync();
    Task<BookDto> GetTopRatedBookAsync();
    Task<List<BookDto>> GetMostBorrowedBooksAsync(int count);
    Task<List<BookDto>> GetMostReservedBooksAsync(int count);
}