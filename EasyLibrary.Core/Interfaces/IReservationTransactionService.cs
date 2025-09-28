using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IReservationTransactionService
{
    Task<List<ReservationTransactionDto>> GetAllAsync();
    Task<ReservationTransactionDto?> GetByIdAsync(ReservationTransactionDto entity);
    Task<ReservationTransactionDto> AddAsync(ReservationTransactionDto entity);
    Task<ReservationTransactionDto> UpdateAsync(ReservationTransactionDto entity);
    Task<bool> DeleteAsync(ReservationTransactionDto entity);
    Task<List<ReservationTransactionDto>> SearchReservationsAsync(string memberId, string bookId);
}