using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Interfaces;

public interface IBorrowTransactionsRepository
{
    Task<List<BorrowTransaction>> GetAllBorrowTransactionsByBookIdAsync(Book book);
    Task<List<BorrowTransaction>> GetAllBorrowTransactionsByMemberIdAsync(Member member);
}