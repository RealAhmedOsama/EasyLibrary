using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Interfaces;

public interface IDashboardRepository
{
    Task<int> GetAllBooksCountAsync();
    Task<int> GetAvailableBooksCountAsync();
    Task<int> GetActiveMembersCountAsync();
    Task<int> GetBorrowedBooksCountAsync(DateTime from, DateTime to);
    Task<List<BorrowTransaction>> GetOverdueBooksAsync();
    Task<List<ReservationTransaction>> GetPendingReservationsAsync();
    Task<Book?> GetTopRatedBookAsync();
    Task<List<Book>> GetMostBorrowedBooksAsync(int count);
    Task<List<Book>> GetMostReservedBooksAsync(int count);
}