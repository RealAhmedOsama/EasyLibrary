using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class MemberService : IMemberService
{
    public async Task<List<MemberDto>> GetAllMembersAsync()
    {
        await using var db = new AppDbContext();
        var members = await db.Members
            .Include(m => m.BorrowTransactions.Where(bt => bt.IsActive))
            .ThenInclude(bt => bt.Book)
            .Include(m => m.ReservationTransactions.Where(rt => rt.IsActive))
            .ThenInclude(rt => rt.Book)
            .ToListAsync();

        return members.Select(DtoMapper.MapMemberToDto).ToList();
    }

    public async Task<MemberDto?> GetMemberByIdAsync(int id)
    {
        await using var db = new AppDbContext();
        var member = await db.Members
            .Include(m => m.BorrowTransactions.Where(bt => bt.IsActive))
            .ThenInclude(bt => bt.Book)
            .Include(m => m.ReservationTransactions.Where(rt => rt.IsActive))
            .ThenInclude(rt => rt.Book)
            .FirstOrDefaultAsync(m => m.Id == id);

        return member == null ? null : DtoMapper.MapMemberToDto(member);
    }

    public async Task AddMemberAsync(MemberDto memberDto)
    {
        await using var db = new AppDbContext();
        var member = DtoMapper.MapDtoToMember(memberDto);
        member.CreatedOn = DateTime.Now;
        member.IsActive = true;

        db.Members.Add(member);
        await db.SaveChangesAsync();
    }

    public async Task UpdateMemberAsync(MemberDto memberDto)
    {
        await using var db = new AppDbContext();
        var member = DtoMapper.MapDtoToMember(memberDto);

        db.Members.Update(member);
        await db.SaveChangesAsync();
    }

    public async Task DeleteMemberAsync(MemberDto memberDto)
    {
        await using var db = new AppDbContext();
        var member = DtoMapper.MapDtoToMember(memberDto);

        db.Members.Remove(member);
        await db.SaveChangesAsync();
    }

    public async Task<List<BookDto>> GetMemberBorrowedBooksAsync(MemberDto memberDto)
    {
        await using var db = new AppDbContext();
        var borrowedBooks = await db.BorrowTransactions
            .Include(bt => bt.Book)
            .ThenInclude(b => b!.Category)
            .Where(bt => bt.MemberId == memberDto.Id && bt.IsActive && bt.ReturnDate == null)
            .Select(bt => bt.Book!)
            .ToListAsync();

        return borrowedBooks.Select(DtoMapper.MapBookToDto).ToList();
    }

    public async Task<List<BookDto>> GetMemberReservedBooksAsync(MemberDto memberDto)
    {
        await using var db = new AppDbContext();
        var reservedBooks = await db.ReservationTransactions
            .Include(rt => rt.Book)
            .ThenInclude(b => b!.Category)
            .Where(rt => rt.MemberId == memberDto.Id && rt.IsActive && rt.ExpirationDate >= DateTime.Now)
            .Select(rt => rt.Book!)
            .ToListAsync();

        return reservedBooks.Select(DtoMapper.MapBookToDto).ToList();
    }
}