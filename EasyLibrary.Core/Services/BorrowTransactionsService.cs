using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class BorrowTransactionsService : IBorrowTransactionsService
{
    public async Task<List<BorrowTransactionDto>> GetAllBorrowTransactionsAsync()
    {
        await using var db = new AppDbContext();
        var borrowTransactions = await db.BorrowTransactions
            .Include(bt => bt.Book)
            .ThenInclude(b => b.Category)
            .Include(bt => bt.Member)
            .ToListAsync();

        return borrowTransactions.Select(DtoMapper.MapBorrowTransactionToDto).ToList();
    }

    public async Task<BorrowTransactionDto?> GetBorrowTransactionByIdAsync(BorrowTransactionDto borrowTransactionDto)
    {
        await using var db = new AppDbContext();
        var borrowTransaction = await db.BorrowTransactions
            .Include(bt => bt.Book)
            .ThenInclude(b => b.Category)
            .Include(bt => bt.Member)
            .FirstOrDefaultAsync(bt => bt.Id == borrowTransactionDto.Id);

        return borrowTransaction == null ? null : DtoMapper.MapBorrowTransactionToDto(borrowTransaction);
    }

    public async Task AddBorrowTransactionAsync(BorrowTransactionDto borrowTransactionDto)
    {
        await using var db = new AppDbContext();

        try
        {
            // Verify that the book and member exist and are active
            var book = await db.Books.FirstOrDefaultAsync(b => b.Id == borrowTransactionDto.BookId && b.IsActive);
            if (book == null)
            {
                throw new InvalidOperationException("Selected book does not exist or is not active.");
            }

            var member = await db.Members.FirstOrDefaultAsync(m => m.Id == borrowTransactionDto.MemberId && m.IsActive);
            if (member == null)
            {
                throw new InvalidOperationException("Selected member does not exist or is not active.");
            }

            // Check if the book is available
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Selected book is not available for borrowing.");
            }

            // Check for existing active borrow for the same book and member
            var existingBorrow = await db.BorrowTransactions
                .FirstOrDefaultAsync(bt => bt.BookId == borrowTransactionDto.BookId &&
                                           bt.MemberId == borrowTransactionDto.MemberId &&
                                           bt.IsActive &&
                                           bt.ReturnDate == null);

            if (existingBorrow != null)
            {
                throw new InvalidOperationException("This member already has an active borrow for this book.");
            }

            // Create the new borrow transaction
            var borrowTransaction = DtoMapper.MapDtoToBorrowTransaction(borrowTransactionDto);
            borrowTransaction.CreatedOn = DateTime.Now;
            borrowTransaction.IsActive = true;

            // Add the transaction
            db.BorrowTransactions.Add(borrowTransaction);

            // Update book availability
            book.IsAvailable = false;

            // Save changes
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Re-throw with more specific error information
            throw new InvalidOperationException($"Error adding borrow transaction: {ex.Message}", ex);
        }
    }

    public async Task UpdateBorrowTransactionAsync(BorrowTransactionDto borrowTransactionDto)
    {
        await using var db = new AppDbContext();

        try
        {
            // Find the existing transaction
            var existingTransaction = await db.BorrowTransactions
                .Include(bt => bt.Book)
                .FirstOrDefaultAsync(bt => bt.Id == borrowTransactionDto.Id);

            if (existingTransaction == null)
            {
                throw new InvalidOperationException("Borrow transaction not found.");
            }

            // Check if this is a return operation
            var wasReturned = existingTransaction.ReturnDate.HasValue;
            var isBeingReturned = borrowTransactionDto.ReturnDate.HasValue;

            // Update the transaction properties
            existingTransaction.BookId = borrowTransactionDto.BookId;
            existingTransaction.MemberId = borrowTransactionDto.MemberId;
            existingTransaction.BorrowDate = borrowTransactionDto.BorrowDate;
            existingTransaction.DueDate = borrowTransactionDto.DueDate;
            existingTransaction.ReturnDate = borrowTransactionDto.ReturnDate;
            existingTransaction.IsActive = borrowTransactionDto.IsActive;

            // Update book availability if return status changed
            if (!wasReturned && isBeingReturned)
            {
                // Book is being returned, make it available
                existingTransaction.Book.IsAvailable = true;
            }
            else if (wasReturned && !isBeingReturned)
            {
                // Book return is being undone, make it unavailable
                existingTransaction.Book.IsAvailable = false;
            }

            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Re-throw with more specific error information
            throw new InvalidOperationException($"Error updating borrow transaction: {ex.Message}", ex);
        }
    }

    public async Task DeleteBorrowTransactionAsync(BorrowTransactionDto borrowTransactionDto)
    {
        await using var db = new AppDbContext();

        try
        {
            // Find the existing transaction
            var existingTransaction = await db.BorrowTransactions
                .Include(bt => bt.Book)
                .FirstOrDefaultAsync(bt => bt.Id == borrowTransactionDto.Id);

            if (existingTransaction == null)
            {
                throw new InvalidOperationException("Borrow transaction not found.");
            }

            // If the book wasn't returned, make it available again
            if (!existingTransaction.ReturnDate.HasValue)
            {
                existingTransaction.Book.IsAvailable = true;
            }

            // Remove the transaction
            db.BorrowTransactions.Remove(existingTransaction);
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error deleting borrow transaction: {ex.Message}", ex);
        }
    }

    public async Task<List<BorrowTransactionDto>> GetAllBorrowTransactionsByBookIdAsync(
        BorrowTransactionDto borrowTransactionDto)
    {
        await using var db = new AppDbContext();
        var borrowTransactions = await db.BorrowTransactions
            .Include(bt => bt.Book)
            .ThenInclude(b => b.Category)
            .Include(bt => bt.Member)
            .Where(bt => bt.BookId == borrowTransactionDto.BookId)
            .ToListAsync();

        return borrowTransactions.Select(DtoMapper.MapBorrowTransactionToDto).ToList();
    }

    public async Task<List<BorrowTransactionDto>> GetAllBorrowTransactionsByMemberIdAsync(
        BorrowTransactionDto borrowTransactionDto)
    {
        await using var db = new AppDbContext();
        var borrowTransactions = await db.BorrowTransactions
            .Include(bt => bt.Book)
            .ThenInclude(b => b.Category)
            .Include(bt => bt.Member)
            .Where(bt => bt.MemberId == borrowTransactionDto.MemberId)
            .ToListAsync();

        return borrowTransactions.Select(DtoMapper.MapBorrowTransactionToDto).ToList();
    }
}