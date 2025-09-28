using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class BorrowTransactionsRepository : GenericRepository<BorrowTransaction>, IBorrowTransactionsRepository
{
    public async Task<List<BorrowTransaction>> GetAllBorrowTransactionsByBookIdAsync(Book book)
    {
        // Explain what this LINQ query does:
        // 1. Filters active borrow transactions for the specified book ID.
        // 2. Orders the results by borrow date in descending order (most recent first).
        return await _dbSet
            .Where(bt => bt.IsActive && bt.BookId == book.Id)
            .OrderByDescending(bt => bt.BorrowDate)
            .ToListAsync();
    }

    public async Task<List<BorrowTransaction>> GetAllBorrowTransactionsByMemberIdAsync(Member member)
    {
        // Explain what this LINQ query does:
        // 1. Filters active borrow transactions for the specified member ID.
        // 2. Orders the results by borrow date in descending order (most recent first).
        return await _dbSet
            .Where(bt => bt.IsActive && bt.MemberId == member.Id)
            .OrderByDescending(bt => bt.BorrowDate)
            .ToListAsync();
    }
}