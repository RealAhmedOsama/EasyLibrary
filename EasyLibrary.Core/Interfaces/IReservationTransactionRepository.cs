using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Interfaces;

public interface IReservationTransactionRepository
{
    Task<List<ReservationTransaction>> SearchReservationsAsync(string memberId, string bookId);
}