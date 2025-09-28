using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IBorrowTransactionsService
{
    Task<List<BorrowTransactionDto>> GetAllBorrowTransactionsAsync();
    Task<BorrowTransactionDto?> GetBorrowTransactionByIdAsync(BorrowTransactionDto borrowTransactionDto);
    Task AddBorrowTransactionAsync(BorrowTransactionDto borrowTransactionDto);
    Task UpdateBorrowTransactionAsync(BorrowTransactionDto borrowTransactionDto);
    Task DeleteBorrowTransactionAsync(BorrowTransactionDto borrowTransactionDto);
    Task<List<BorrowTransactionDto>> GetAllBorrowTransactionsByBookIdAsync(BorrowTransactionDto borrowTransactionDto);
    Task<List<BorrowTransactionDto>> GetAllBorrowTransactionsByMemberIdAsync(BorrowTransactionDto borrowTransactionDto);
}