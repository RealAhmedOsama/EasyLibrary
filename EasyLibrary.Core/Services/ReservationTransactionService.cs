using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class ReservationTransactionService : IReservationTransactionService
{
    public async Task<List<ReservationTransactionDto>> GetAllAsync()
    {
        await using var db = new AppDbContext();
        var reservations = await db.ReservationTransactions
            .Include(rt => rt.Book)
            .ThenInclude(b => b.Category)
            .Include(rt => rt.Member)
            .ToListAsync();

        return reservations.Select(DtoMapper.MapReservationTransactionToDto).ToList();
    }

    public async Task<ReservationTransactionDto?> GetByIdAsync(ReservationTransactionDto entity)
    {
        await using var db = new AppDbContext();
        var reservation = await db.ReservationTransactions
            .Include(rt => rt.Book)
            .ThenInclude(b => b.Category)
            .Include(rt => rt.Member)
            .FirstOrDefaultAsync(rt => rt.Id == entity.Id);

        return reservation == null ? null : DtoMapper.MapReservationTransactionToDto(reservation);
    }

    public async Task<ReservationTransactionDto> AddAsync(ReservationTransactionDto entity)
    {
        await using var db = new AppDbContext();
        var reservation = DtoMapper.MapDtoToReservationTransaction(entity);
        reservation.CreatedOn = DateTime.Now;
        reservation.IsActive = true;

        db.ReservationTransactions.Add(reservation);
        await db.SaveChangesAsync();

        entity.Id = reservation.Id;
        entity.CreatedOn = reservation.CreatedOn;
        entity.IsActive = reservation.IsActive;

        return entity;
    }

    public async Task<ReservationTransactionDto> UpdateAsync(ReservationTransactionDto entity)
    {
        await using var db = new AppDbContext();
        var reservation = DtoMapper.MapDtoToReservationTransaction(entity);

        db.ReservationTransactions.Update(reservation);
        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(ReservationTransactionDto entity)
    {
        try
        {
            await using var db = new AppDbContext();
            var reservation = DtoMapper.MapDtoToReservationTransaction(entity);

            db.ReservationTransactions.Remove(reservation);
            await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<ReservationTransactionDto>> SearchReservationsAsync(string memberId, string bookId)
    {
        await using var db = new AppDbContext();
        var query = db.ReservationTransactions
            .Include(rt => rt.Book)
            .ThenInclude(b => b.Category)
            .Include(rt => rt.Member)
            .AsQueryable();

        if (int.TryParse(memberId, out var memberIdInt))
        {
            query = query.Where(rt => rt.MemberId == memberIdInt);
        }

        if (int.TryParse(bookId, out var bookIdInt))
        {
            query = query.Where(rt => rt.BookId == bookIdInt);
        }

        var reservations = await query.ToListAsync();

        return reservations.Select(DtoMapper.MapReservationTransactionToDto).ToList();
    }
}